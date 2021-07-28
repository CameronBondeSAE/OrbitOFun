using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class DestroyedState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            // Play explosion effect
            // Remove player model
        }

        public override void Execute()
        {
            base.Execute();
            
            // Add to timer until respawn
            // When timer hits threshold, respawn player at start
        }

        public override void Exit()
        {
            base.Exit();
            
            // Stop explosion effect
        }
    }
}