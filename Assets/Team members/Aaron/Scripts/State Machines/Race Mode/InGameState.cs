using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class InGameState : RaceModeStateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //enter RaceControlState
            //not sure about initialising gravity etc, whether that's controlled here or outside
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