using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LukeBaker;
using Mirror;
using Tim;
using Zach;
using Tom;
using RileyMcGowan;

namespace AaronMcDougall
{
    public class InGameState : StateBase
    {
        private ZachsPlayerActions zachsPlayerActions;
        public float speed;
        public StateBase nextState;
        private int numberOfShips;
        private int deathCounter;
        private CustomNetworkManager customNetworkManager;

        private void Awake()
        {
            customNetworkManager = FindObjectOfType<CustomNetworkManager>();
        }

        public override void Enter()
        {
            base.Enter();
            deathCounter = 0;
            EnablePlayerControls();
            customNetworkManager.gameManager.gameModeBase.ActivateAllIGameModeInteractables();
            numberOfShips = customNetworkManager.playerInstances.Count;
            
            foreach (GameObject playerToUnFreeze in customNetworkManager.playerInstances)
            {
                GetComponent<RaceModeRules>().RpcUnFreezePlayer(playerToUnFreeze.GetComponent<NetworkIdentity>());
            }

            foreach (var playerInstance in customNetworkManager.playerInstances)
            {
                Rigidbody rb = playerInstance.GetComponent<Rigidbody>();
                // rb.AddForce(playerInstance.transform.up * speed, ForceMode.VelocityChange);
                rb.velocity                                      =  playerInstance.transform.up * speed;
                playerInstance.GetComponent<Health>().deathEvent += OndeathEvent;
            }

            FindObjectOfType<EndTrigger>().PlayerTriggerEnterEvent += GoalReached;
            //enter RaceControlState
            //not sure about initialising gravity etc, whether that's controlled here or outside
        }


        public override void Execute()
        {
            base.Execute();
            if (deathCounter >= numberOfShips)
            {
                FindObjectOfType<RaceModeRules>().Activate();
            }
        }

        public override void Exit()
        {
            base.Exit();
            //FindObjectOfType<GameManager>().GameEnd();
            FindObjectOfType<EndTrigger>().PlayerTriggerEnterEvent -= GoalReached;
            foreach (var playerInstance in customNetworkManager.playerInstances)
            {
                playerInstance.GetComponent<Health>().deathEvent -= OndeathEvent;
            }
        }

        public void EnablePlayerControls()
        {
            GetComponent<RaceModeRules>().EnablePlayerControls();
        }

        private void GoalReached(PlayerBase playerBase)
        {
            Debug.Log("Reached Goal");
            GetComponent<RaceModeRules>().leaderboard.Add(playerBase);
            GetComponent<RaceModeRules>().RpcFreezePlayer(playerBase.GetComponent<NetworkIdentity>());
        }

        private void StartEndGame()
        {
            GetComponent<RaceModeStateManager>().ChangeState(nextState);
        }

        private void OndeathEvent(Health obj)
        {
            deathCounter++;
        }
    }
}