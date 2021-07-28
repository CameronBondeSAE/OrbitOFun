using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AaronMcDougall
{
    public class PreTimerState : RaceModeStateBase
    {
        public override void Enter()
        {
            base.Enter();
            
            //open game lobby
            //launch race mode setup
                //map creation
                //player spawn points
            //Get ready message?
        }

        public override void Execute()
        {
            base.Execute();
            //allow players to join lobby
            //if players choosing starting point, give access
            //else, assign starting points to players
        }

        public override void Exit()
        {
            base.Exit();
            
            //hide ready message if applicable
            //close lobby (to new players)
        }
    }
}