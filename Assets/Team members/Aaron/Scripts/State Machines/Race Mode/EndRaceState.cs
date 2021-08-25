using System.Collections;
using System.Collections.Generic;

using UnityEngine;


namespace Rob
{
    public class EndRaceState : StateBase
    {

        public GameObject endRaceTimer;
        public float countDownAmount;
        public float countDownTo;
        public StateBase nextState;


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
                SwitchState();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public void GoalReached()
        {
            //stop race timer if there is one
            StartCoroutine(SpawnEndRaceTimer());
        }

        public IEnumerator SpawnEndRaceTimer()
        {
            for (float i = countDownAmount; i > countDownTo ; i--)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }
        }

        public void SwitchState()
        {
            GetComponent<StateManager>().ChangeState(nextState);
        }
    }
}
