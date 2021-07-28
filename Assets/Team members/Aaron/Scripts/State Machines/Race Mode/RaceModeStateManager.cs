using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{     
    public class RaceModeStateManager : MonoBehaviour
    {
        public RaceModeStateBase currentState;

        public void ChangeSTate(RaceModeStateBase newState)
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