using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class CreditsState : MenuUIStateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin'");
            //play credits
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye");
        }
    }
}
