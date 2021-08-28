﻿using System.Collections;
using System.Collections.Generic;
using Damien;
using RileyMcGowan;
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

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Countdown");

            SpawnCountdown();
            StartCoroutine(CountDownTimer());
            GetComponent<BattleModeRules>().RpcEnableArrowControls();
            GetComponent<RaceModeRules>();
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
                yield return new WaitForSeconds(1);
            }

            DestroyCountdownTimer();
            NextState();
            GetComponent<RaceModeRules>().DisableAllControls();
        }

        void DestroyCountdownTimer()
        {
            Destroy(countdownCopy.gameObject);
        }

        void NextState()
        {
            GetComponent<StateManager>().ChangeState(nextState);
        }
    }
}