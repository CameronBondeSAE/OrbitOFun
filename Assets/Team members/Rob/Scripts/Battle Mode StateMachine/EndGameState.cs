using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class EndGameState : BattleModeStateBase
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
            //show end game view, scoreboard etc etc
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye");
        }
    }
}