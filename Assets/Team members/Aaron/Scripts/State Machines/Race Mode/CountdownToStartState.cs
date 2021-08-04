using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class CountdownToStartState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //is this where ArrowAimState is entered?
            //also need to enter LaunchState at some point through here perhaps
            //run and show the race start countdown timer
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}