using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronMcDougall
{
    public class RacePlayerStateManager : MonoBehaviour
    {
        public RacePlayerStateBase currentState;

        public void ChangeState(RacePlayerStateBase newState)
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