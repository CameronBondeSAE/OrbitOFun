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

        public override void Enter()
        {
            base.Enter();
            EnablePlayerControls();

            foreach (var playerInstance in FindObjectOfType<CustomNetworkManager>().playerInstances)
            {
                playerInstance.GetComponent<Rigidbody>().AddForce(playerInstance.transform.up * speed, ForceMode.VelocityChange);
            }
            
            FindObjectOfType<EndTrigger>().TriggerEnterEvent += GoalReached;

            player = GetComponent<PlayerBase>();


            //enter RaceControlState
            //not sure about initialising gravity etc, whether that's controlled here or outside
        }

        public override void Execute()
        {
            base.Execute();

        }

        public override void Exit()
        {
            base.Exit();
            FindObjectOfType<GameManager>().GameEnd();
            
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
    }
}