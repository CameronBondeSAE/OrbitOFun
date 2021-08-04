using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

namespace RileyMcGowan
{
    public class RaceModeRules : GameModeBase
    {
        //Private Vars
        [Tooltip("This is the delay between the Win UI and Main Menu.")]
        private float timeToWait = 5;
        private float waitTimerToUI = 5;
        
        //Public Vars
        public GameObject playerToSpawn;
        public GameObject cameraToSpawn;
        public GameObject countdownToSpawn;
        public GameObject sceneToSpawn;
        
        public override void Activate()
        {
            base.Activate(); //Activate the mode
            //General Code
            //Spawn Players > Network Manager
            //Spawn Countdown > Set Time

            //Subscriptions
            //Goal Reached > Start "EndOfRoundTimer()"
        }

        private void EndOfRoundTimer()
        {
            StartCoroutine(EndOfGame(timeToWait, waitTimerToUI));
        }

        private IEnumerator EndOfGame(float waitUIToMain, float waitTimerToUI)
        {
            //Start end of game timer
            yield return new WaitForSeconds(waitTimerToUI + 1f); //Wait for UI
            //Show Win UI
            yield return new WaitForSeconds(waitUIToMain); //Wait for exit to main
            //Exit to main menu
        }
    }
}