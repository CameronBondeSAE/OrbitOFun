using System.Collections;
using System.Collections.Generic;
using John;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using Zach;
using LukeBaker;

namespace RileyMcGowan
{
    public class RaceModeRules : GameModeBase
    {
        //Private Vars
        [Tooltip("This is the delay between the Win UI and Main Menu.")]
        private float timeToWait = 5;
        private float waitTimerToUI = 10;
        private CustomNetworkManager mainNetworkManager;
        private List<GameObject> players;
        private Countdown timer;
        
        //Public Vars
        public GameObject playerToSpawn;
        public GameObject cameraToSpawn;
        public GameObject countdownToSpawn;
        public GameObject sceneToSpawn;
        
        public override void Activate()
        {
            base.Activate(); //Activate the mode
            //General Code
            mainNetworkManager = FindObjectOfType<CustomNetworkManager>();
            players = mainNetworkManager.playerPrefabs;
            mainNetworkManager.SpawnPlayers(); //Spawn Players > Network Manager
            GameObject spawnedCountdown = Instantiate(countdownToSpawn, Vector3.zero, quaternion.identity); //Spawn Countdown > Set Time
            timer = spawnedCountdown.GetComponent<Countdown>();
            timer.roundTimer = 100;
            timer.RPCStartRound();
            //Subscriptions
            //TODO Subscribe to "Goal Reached" > Start "EndOfRoundTimer()"
        }

        private void EndOfRoundTimer()
        {
            StartCoroutine(EndOfGame(timeToWait, waitTimerToUI));
        }

        private IEnumerator EndOfGame(float waitUIToMain, float waitTimerToUI)
        {
            timer.roundTimer = waitTimerToUI; //Start end of game timer
            yield return new WaitForSeconds(waitTimerToUI + 1f); //Wait for UI
            //TODO Show Win UI
            yield return new WaitForSeconds(waitUIToMain); //Wait for exit to main
            //TODO Exit to main menu
        }
    }
}