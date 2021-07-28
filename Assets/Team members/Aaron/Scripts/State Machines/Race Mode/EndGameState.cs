using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class EndGameState : RaceModeStateBase
    {
        public override void Enter()
        {
            base.Enter();

            //Show winner message, player username
            //enter RaceEndState?
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Exit()
        {
            base.Exit();
            
            //return to main menu/mode select/enter PreTimerState
        }
    }

}
