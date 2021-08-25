using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

namespace Rob
{
    public class GetReadyState : StateBase
    {
        public float readyTime = 5f;
        public StateBase nextState;
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered GetReady");
            
            DisablePlayerArrows();
            StartCoroutine(GetReadyCountdown());
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' GetReady");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye GetReady");
        }

        public void DisablePlayerArrows()
        {
            // TODO: Replace with DisableControls function from BattleModeRules when it gets written
            PlayerArrow[] arrows = FindObjectsOfType<PlayerArrow>();
            foreach (PlayerArrow a in arrows)
            {
                a.DisableControls();
            }
        }

        public IEnumerator GetReadyCountdown()
        {
            Debug.Log("Get ready!");
            yield return new WaitForSeconds(readyTime);
            GetComponent<StateManager>().ChangeState(nextState);
        }
    }
}