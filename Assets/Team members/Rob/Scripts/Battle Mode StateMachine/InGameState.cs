using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class InGameState : BattleModeStateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered InGame");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' InGame");
            // game stuff
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye InGame" );
        }
    }
}