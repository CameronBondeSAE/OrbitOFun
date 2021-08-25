using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class EndRoundState : StateBase
    {

        public GameObject scoreboardUI;
        public float showScore;
        public StateBase nextState;
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered EndRound");
            ShowScore();
            
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' EndRound");
            //scoreboard? time? etc etc
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye EndRound");
        }

        public void ShowScore()
        {
            Instantiate(scoreboardUI);
            StartCoroutine(ScoreboardTimer());
        }

        private IEnumerator ScoreboardTimer()
        {
            yield return new WaitForSeconds(showScore);
            GetComponent<StateManager>().ChangeState(nextState);
        }
        
    }
}