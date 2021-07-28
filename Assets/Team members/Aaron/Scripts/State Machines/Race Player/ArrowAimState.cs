using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class ArrowAimState : RacePlayerStateBase
    {
        public override void Enter()
        {
            base.Enter();
            //load player ship visual at spawn point
            //load arrow visual
        }

        public override void Execute()
        {
            base.Execute();
            
            //give player control of arrow
                //get mouse/arrowKey input
                //rotate arrow accordingly
        }

        public override void Exit()
        {
            base.Exit();
            
            //lock off arrow movement control
            //remove arrow visual?
        }
    }
}
