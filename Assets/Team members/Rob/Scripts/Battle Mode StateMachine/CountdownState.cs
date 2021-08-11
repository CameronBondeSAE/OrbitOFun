using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class CountdownState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Countdown");
            //start countdown
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' Countdown");
            //anything that needs to happen during countdown?
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye Countdown");
            //enter next state
        }
    }
}