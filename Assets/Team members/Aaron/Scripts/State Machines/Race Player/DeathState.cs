using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class DeathState : RacePlayerStateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //run death event
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            //reset player position to spawn point
            //enter ArrowAimState
        }
    }
}