using System.Collections;
using System.Collections.Generic;
using Damien;
using LukeBaker;
using Tom;
using UnityEngine;

namespace Rob
{
    public class InGameState : StateBase
    {
        private float countAmount = 3f;
        public StateBase repeatState;
        private bool inGame;
        public StateBase nextState;
        private BattleModeRules bmRules;

        public override void Enter()
        {
            base.Enter();
            inGame = true;
            bmRules = FindObjectOfType<BattleModeRules>();
            
            GetComponent<BattleModeRules>().RpcEnableArrowControls();
            StartCoroutine(Counter(3));
            Debug.Log("Entered InGame");
        }

        public override void Execute()
        {
            base.Execute();
            Debug.Log("Doin' InGame");
            if (bmRules != null)
            {
                if (bmRules.baseCount <= 1)
                {
                    FindObjectOfType<StateManager>().ChangeState(nextState);
                    //bmRules.EndGame();
                }
            }
            // game stuff
        }

        public override void Exit()
        {
            base.Exit();
            inGame = false;
            Debug.Log("Bye InGame");
        }

        IEnumerator Counter(int delay)
        {
            while (inGame)
            {
                GetComponent<BattleModeRules>().RpcFireMeteor();
                yield return new WaitForSeconds(delay);
                //check game status
            }
        }
    }
}