using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;

namespace Rob
{
    public class CountdownState : StateBase
    {

        public GameObject countdownPrefab;
        public GameObject countdownCopy;
        public float countAmount;
        public StateBase nextState;

        private PlayerArrow[] playerArrows;
        
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Countdown");

            SpawnCountdown();
            StartCoroutine(CountDownTimer());
            ArrowControlEnable();
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye Countdown");
        }

        public void SpawnCountdown()
        {
            countdownCopy = Instantiate(countdownPrefab);
        }

        IEnumerator CountDownTimer()
        {
            for (int i = 0; i < countAmount; i++)
            {
                Debug.Log(i);
                //allow controls
                //show count on IO
                yield return new WaitForSeconds(1);
            }

            DestroyCountdownTimer();
            NextState();
            ArrowControlDisable();
        }

        void DestroyCountdownTimer()
        {
            Destroy(countdownCopy.gameObject);
        }

        void NextState()
        {
            GetComponent<StateManager>().ChangeState(nextState);
        }

        void ArrowControlEnable()
        {
            playerArrows = FindObjectsOfType<PlayerArrow>();
            foreach (PlayerArrow a in  playerArrows)
            {
                a.EnableControls();
            }
        }

        void ArrowControlDisable()
        {
            foreach (PlayerArrow a in playerArrows)
            {
                a.DisableControls();
            }
        }


    }
}