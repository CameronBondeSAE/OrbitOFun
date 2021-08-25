using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using John;
using Mirror;
using RileyMcGowan;
using Tom;

namespace AaronMcDougall
{
    public class CountdownToStartState : StateBase
    {
        public GameObject countdownPrefab;
        private Countdown spawnedCountdown;
        public StateBase nextState;
        
        public override void Enter()
        {
            base.Enter();
            
            SpawnCountdown();
            EnableArrowControls();

            //is this where ArrowAimState is entered?
            //also need to enter LaunchState at some point through here perhaps
            //run and show the race start countdown timer
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            DestroyCountdown();
        }

        public void SpawnCountdown()
        {
            spawnedCountdown = Instantiate(countdownPrefab).GetComponentInChildren<Countdown>();
            NetworkServer.Spawn(spawnedCountdown.gameObject);
            spawnedCountdown.RPCStartRound();
            spawnedCountdown.CountdownEndedEvent += StartGameState;
        }

        public void DestroyCountdown()
        {
            Destroy(spawnedCountdown.gameObject);
            spawnedCountdown.CountdownEndedEvent -= StartGameState;
        }

        public void EnableArrowControls()
        {
            GetComponent<RaceModeRules>().RpcEnableArrowControls();
        }

        public void StartGameState()
        {
            GetComponent<RaceModeStateManager>().ChangeState(nextState);
        }
    }
}