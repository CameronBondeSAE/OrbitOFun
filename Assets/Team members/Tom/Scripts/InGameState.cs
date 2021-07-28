using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class InGameState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            // Set up level
            // Spawn player objects in
            // Allow player controls
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            // Disable player controls
        }
    }
}