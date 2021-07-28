using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{
    public class EndRoundState : BattleModeStateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered EndRound");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' EndRound");
            //scoreboard? time? etc etc
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye EndRound");
        }
    }
}