using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class RaceEndState : RacePlayerStateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //lock off player controls/allow players to fly aimlessly in background
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