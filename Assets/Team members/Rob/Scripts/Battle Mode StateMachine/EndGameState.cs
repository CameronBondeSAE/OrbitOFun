using System.Collections;
using System.Collections.Generic;
using AaronMcDougall;
using Mirror;
using Tom;
using UnityEngine;

namespace Rob
{
    public class EndGameState : StateBase
    {
        public GameObject endGameUI;
        private GameObject spawnedUI;
        public float showUITime = 10f;
        private float timer;
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Avengers Entered the EndGame");
            
            SpawnEndGameUI();
            SetUITime();
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' EndGame");
            //show end game view, scoreboard etc etc

            CountUITimer();
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye EndGame");
            
            DestroyUI();
        }

        public void SpawnEndGameUI()
        {
            spawnedUI = Instantiate(endGameUI);
            NetworkServer.Spawn(spawnedUI);
            //spawnedUI.GetComponent<EndGameUI>().SetWinnerName(//Get winner player name);
        }

        public void DestroyUI()
        {
            Destroy(spawnedUI);
        }

        public void SetUITime()
        {
            timer = showUITime;
        }

        public void CountUITimer()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                GetComponent<RaceModeStateManager>().ChangeState(GetComponent<PreTimerState>());
            }
        }
    }
}