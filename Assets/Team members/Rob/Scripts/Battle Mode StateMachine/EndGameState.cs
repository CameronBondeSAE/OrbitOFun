using System.Collections;
using System.Collections.Generic;
using Damien;
using Mirror;
using UnityEngine;

namespace Rob
{
    public class EndGameState : StateBase
    {
        public GameObject endGameUI;
        private GameObject spawnedUI;
        public float showUITime = 10f;
        public StateBase nextState;
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Avengers Entered the EndGame");
            
            SpawnEndGameUI();
            StartCoroutine(ShowUICountdown());
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' EndGame");
            //show end game view, scoreboard etc etc
            
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
            Destroy(spawnedUI.gameObject);
        }

        public IEnumerator ShowUICountdown()
        {
            yield return new WaitForSeconds(showUITime);
            //GetComponent<StateManager>().ChangeState(nextState);
            FindObjectOfType<BattleModeRules>().EndGame();
        }
    }
}