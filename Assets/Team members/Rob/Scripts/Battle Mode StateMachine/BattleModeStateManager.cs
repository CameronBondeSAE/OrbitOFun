using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class BattleModeStateManager : MonoBehaviour
    {
        public BattleModeStateBase currentState;

        public void ChangeState(BattleModeStateBase newState)
        {
            if (currentState != null)
            {
                currentState.active = false;
                currentState.Exit();
            }
		
            if (newState != null)
            {
                newState.active = true;
                newState.Enter(); 
                currentState = newState;
            }
        }
        
        public void UpdateCurrentState()
        {
            currentState?.Execute();
        }
        
        private void FixedUpdate()
        {
            //Remind what the current state is
            UpdateCurrentState();
        }
    }
}