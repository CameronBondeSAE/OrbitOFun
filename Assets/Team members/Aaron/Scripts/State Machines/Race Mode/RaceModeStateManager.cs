using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronMcDougall
{     
    public class RaceModeStateManager : MonoBehaviour
    {
        public StateBase currentState;

        private void FixedUpdate()
        {
            UpdateCurrentState();
        }

        void UpdateCurrentState()
        {
            currentState?.Execute();
        }

        public void ChangeState(StateBase newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            if (newState != null)
            {
                newState.Enter();
                currentState = newState;
            }
        }
    }
}