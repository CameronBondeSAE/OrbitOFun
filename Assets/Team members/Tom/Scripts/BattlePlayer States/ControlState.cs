using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class ControlState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            // Show arrow visual
        }

        public override void Execute()
        {
            base.Execute();
        
            // Detect input
            // Rotate arrow based on input
        }

        public override void Exit()
        {
            base.Exit();
        
            // Hide arrow visual
        }
    }
}