using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LukeBaker;
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
        private PlayerBase player;
        private int numberOfShips;
        private int deathCounter;

        public override void Enter()
        {
            base.Enter();
            deathCounter = 0;
            
            EnablePlayerControls();

            numberOfShips = FindObjectOfType<CustomNetworkManager>().playerInstances.Count;

            foreach (GameObject playerToUnFreeze in FindObjectOfType<CustomNetworkManager>().playerInstances)
            {
                GetComponent<RaceModeRules>().UnFreezePlayer(playerToUnFreeze.GetComponent<PlayerBase>());
            }

            foreach (var playerInstance in FindObjectOfType<CustomNetworkManager>().playerInstances)
            {
                playerInstance.GetComponent<Rigidbody>()
                    .AddForce(playerInstance.transform.up * speed, ForceMode.VelocityChange);
                FindObjectOfType<Health>().deathEvent += OndeathEvent;
            }

            FindObjectOfType<EndTrigger>().TriggerEnterEvent += GoalReached;

            player = GetComponent<PlayerBase>();


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
            FindObjectOfType<GameManager>().GameEnd();
            FindObjectOfType<EndTrigger>().TriggerEnterEvent -= GoalReached;
            FindObjectOfType<Health>().deathEvent -= OndeathEvent;
        }

        public void EnablePlayerControls()
        {
            GetComponent<RaceModeRules>().RpcEnablePlayerControls();
        }

        private void GoalReached()
        {
            Debug.Log("Reached Goal");
            GetComponent<RaceModeRules>().leaderboard.Add(player);
            GetComponent<RaceModeRules>().FreezePlayer(player);
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