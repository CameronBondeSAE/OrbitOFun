using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rob
{
    public class LobbyState : StateBase
    {
        public override void Enter()
        {
            base.Enter();
            Debug.Log("Entered Lobby");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' Lobby");
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("Bye Lobby");
        }
    }
}
