using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tim;
using Zach;
using Tom;

namespace AaronMcDougall
{
    public class InGameState : StateBase
    {
        private ZachsPlayerActions zachsPlayerActions;
        private PlayerBase playerBase;
        private PlayerArrow playerArrow;
        private RaceModePlayer player;
        private Rigidbody rb;
        public float speed;
        public StateBase nextState;

        public override void Enter()
        {
            base.Enter();
            EnablePlayerControls();
            playerBase = FindObjectOfType<PlayerBase>();
            playerArrow = FindObjectOfType<PlayerArrow>();
            player = FindObjectOfType<RaceModePlayer>();
            rb = player.GetComponent<Rigidbody>();
            
            player.transform.eulerAngles = playerArrow.GetEulerAngles();
            rb.AddForce(transform.position * speed);
            
            FindObjectOfType<EndTrigger>().TriggerEnterEvent += GoalReached;
        

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
            playerBase.EnableControls();
        }

        private void GoalReached()
        {
            Debug.Log("Reached Goal");
        }

        private void StartEndGame()
        {
            GetComponent<RaceModeStateManager>().ChangeState(nextState);
        }
    }
}