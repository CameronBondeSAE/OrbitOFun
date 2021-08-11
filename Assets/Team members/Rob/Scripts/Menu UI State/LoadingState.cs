using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class LoadingState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Loading");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' Loading");
            //any loading animations
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye Loading");
        }
    }
}
