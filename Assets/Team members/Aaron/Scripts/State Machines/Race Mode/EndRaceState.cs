using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;

namespace AaronMcDougall
{
    public class EndRaceState : StateBase
    {
        public float countDownAmount;
        public float countDownTo;
        public StateBase nextState;
        public float showScoreBoardTime;


        public override void Enter()
        {
            base.Enter();
            FindObjectOfType<EndTrigger>().TriggerEnterEvent += GoalReached;
        }

        public override void Execute()
        {
            base.Execute();
            if (countDownAmount <= countDownTo)
            {
                ShowScoreBoard();
            }
        }

        public override void Exit()
        {
            base.Exit();
            FindObjectOfType<EndTrigger>().TriggerEnterEvent -= GoalReached;
        }

        public void GoalReached()
        {
            //stop race timer if there is one
            Debug.Log(GetComponent<RaceModeRules>().leaderboard + " finished");
            StartCoroutine(SpawnEndRaceTimer());
        }

        public IEnumerator SpawnEndRaceTimer()
        {
            for (float i = countDownAmount; i > countDownTo; i--)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }
        }

        public void ShowScoreBoard()
        {
            
            StartCoroutine(CountdownToSwitchState());
        }

        public IEnumerator CountdownToSwitchState()
        {
            yield return new WaitForSeconds(showScoreBoardTime);
            SwitchState();
        }

        public void SwitchState()
        {
            GetComponent<RaceModeStateManager>().ChangeState(nextState);
        }
    }
}