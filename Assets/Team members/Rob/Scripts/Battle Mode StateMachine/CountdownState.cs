using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class CountdownState : BattleModeStateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
            //start countdown
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin'");
            //anything that needs to happen during countdown?
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye");
            //enter next state
        }
    }
}