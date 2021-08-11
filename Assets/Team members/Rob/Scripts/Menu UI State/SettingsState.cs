using System.Collections;
using System.Collections.Generic;
using Rob;
using UnityEngine;



namespace Rob
{
    public class SettingsState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Settings");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' Settings");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye Settings");
        }
    }
}
