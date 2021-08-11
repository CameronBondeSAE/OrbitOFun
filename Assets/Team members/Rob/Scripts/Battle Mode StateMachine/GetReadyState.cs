using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class GetReadyState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered GetReady");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' GetReady");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye GetReady");
        }
    }
}