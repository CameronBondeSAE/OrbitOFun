using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class LaunchState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            // Add force to player based on direction
            // Play rocket trail particle system
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            // Stop rocket trail particle system
        }
    }
}