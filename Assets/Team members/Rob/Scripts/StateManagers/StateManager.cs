using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class StateManager : MonoBehaviour
    {
        public StateBase currentState;

        public void ChangeState(StateBase newState)
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