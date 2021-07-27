using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class StateManager : MonoBehaviour
    {
        public StateBase currentState;

        public void ChangeState(StateBase newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        private void Update()
        {
            currentState?.Execute();
        }
    }
}