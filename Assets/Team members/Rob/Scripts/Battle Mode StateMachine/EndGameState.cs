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
            Debug.Log("Avengers Entered the EndGame");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' EndGame");
            //show end game view, scoreboard etc etc
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye EndGame");
        }
    }
}