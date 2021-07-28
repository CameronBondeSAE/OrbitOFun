using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AaronMcDougall
{
    public class LaunchState : RacePlayerStateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //show launch power visual
        }

        public override void Execute()
        {
            base.Execute();
            
            //give player launch power control
                //maybe key press/hold to charge power?
        }

        public override void Exit()
        {
            base.Exit();
            
            //hide launch power visual
        }
    }
}