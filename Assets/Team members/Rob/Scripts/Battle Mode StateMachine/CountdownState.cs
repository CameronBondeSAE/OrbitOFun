using System.Collections;
using System.Collections.Generic;
using Damien;
using RileyMcGowan;
using Tom;
using UnityEngine;
using UnityEngine.Serialization;

namespace Rob
{
    public class CountdownState : StateBase
    {

        public GameObject countdownPrefab;
        public GameObject spawnedCountdown;
        public float countAmount;
        public StateBase nextState;

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Countdown");

            SpawnCountdown();
            StartCoroutine(CountDownTimer());
            GetComponent<BattleModeRules>().RpcEnableArrowControls();
            GetComponent<BattleModeRules>();
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
            spawnedCountdown = Instantiate(countdownPrefab);
        }

        IEnumerator CountDownTimer()
        {
            for (int i = 0; i < countAmount; i++)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }

            DestroyCountdownTimer();
            NextState();
            GetComponent<BattleModeRules>().DisableControls();
        }

        void DestroyCountdownTimer()
        {
            Destroy(spawnedCountdown);
        }

        void NextState()
        {
            GetComponent<StateManager>().ChangeState(nextState);
        }
    }
}