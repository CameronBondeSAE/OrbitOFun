using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

namespace AaronMcDougall
{
    public class EndGameState : StateBase
    {
        public GameObject endGameUIPrefab;
        private GameObject spawnedUI;
        public float showUITime = 10f;
        
        public override void Enter()
        {
            base.Enter();

            //Show winner message, player username
            //enter RaceEndState?
            
            SpawnEndGameUI();
            StartCoroutine(ShowUICountdown());
        }

        public override void Execute()
        {
            base.Execute();
            
        }

        public override void Exit()
        {
            base.Exit();
            
            //return to main menu/mode select/enter PreTimerState
            
            DestroyUI();
        }

        public void SpawnEndGameUI()
        {
            spawnedUI = Instantiate(endGameUIPrefab);
            NetworkServer.Spawn(spawnedUI);
            //spawnedUI.GetComponent<EndGameUI>().SetWinnerName(//Get winner player name);
        }

        public void DestroyUI()
        {
            Destroy(spawnedUI.gameObject);
        }

        public IEnumerator ShowUICountdown()
        {
            yield return new WaitForSeconds(showUITime);
            GetComponent<RaceModeStateManager>().ChangeState(GetComponent<PreTimerState>());
        }
    }

}
