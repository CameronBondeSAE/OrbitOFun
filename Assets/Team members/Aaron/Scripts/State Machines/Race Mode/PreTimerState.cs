using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LukeBaker;
using Mirror;
using RileyMcGowan;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using Zach;

namespace AaronMcDougall
{
    public class PreTimerState : StateBase
    {
        public GameObject messagePrefab;
        private GameObject messageCopy;
        public float readyTime;

        public StateBase nextState;

        public override void Enter()
        {
            base.Enter();

            if (messagePrefab != null)
            {
                StartCoroutine(GetReadyMessage());
            }

            foreach (GameObject playerToFreeze in FindObjectOfType<CustomNetworkManager>().playerInstances)
            {
                GetComponent<RaceModeRules>().FreezePlayer(playerToFreeze.GetComponent<PlayerBase>());
            }
            
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
        }

        IEnumerator GetReadyMessage()
        {
            messageCopy = Instantiate(messagePrefab);

            for (int i = 0; i < readyTime; i++)
            {
                Debug.Log(i);
                yield return new WaitForSeconds(1);
            }
            
            DestroyMessage();
            ChangeToNextState();
        }

        void DestroyMessage()
        {
            Destroy(messageCopy.gameObject);
        }

        void ChangeToNextState()
        {
            GetComponent<RaceModeStateManager>().ChangeState(nextState);
        }
    }
}