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
            for (int i = 0; i < players.Count; i++)
            {
                GameObject playerPrefab = players[i];
                GameObject spawnedCountdown = Instantiate(countdownToSpawn, playerPrefab.transform.position, quaternion.identity); //Spawn Countdown > Set Time
                spawnedCountdown.transform.parent = playerPrefab.transform;
                spawnedCountdown.GetComponent<Countdown>().roundTimer = 100;
            }
            //Subscriptions
            //TODO Subscribe to "Goal Reached" > Start "EndOfRoundTimer()"
        }

        private void EndOfRoundTimer()
        {
            StartCoroutine(EndOfGame(timeToWait, waitTimerToUI));
        }

        private IEnumerator EndOfGame(float waitUIToMain, float waitTimerToUI)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].GetComponentInChildren<Countdown>().roundTimer = waitTimerToUI; //Start end of game timer
            }
            yield return new WaitForSeconds(waitTimerToUI + 1f); //Wait for UI
            for (int i = 0; i < players.Count; i++)
            {
                //TODO Show Win UI
            }
            yield return new WaitForSeconds(waitUIToMain); //Wait for exit to main
            for (int i = 0; i < players.Count; i++)
            {
                //TODO Exit to main menu
            }
        }
    }
}