using System;
using System.Collections;
using System.Collections.Generic;
using John;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using Zach;
using LukeBaker;
using UnityEngine.SceneManagement;

namespace RileyMcGowan
{
    public class RaceModeRules : GameModeBase
    {
        //Private Vars
        [Tooltip("This is the delay between the Win UI and Main Menu.")]
        private float timeToWait = 5;
        private float waitTimerToUI = 10;
        private CustomNetworkManager mainNetworkManager;
        private Countdown timer;
        private GameObject endGoal;
        private bool isActive = false;

        //Public Vars
        public GameObject cameraToSpawn;
        public GameObject sceneToSpawn;
        
        //Might need to add ActivateAllIGameModeInteractables so we can use common game objects
        
        public override void Activate()
        {
            base.Activate(); //Activate the mode
            ActivateAllIGameModeInteractables();
            //General Code
            if (mainNetworkManager == null)
            {
                mainNetworkManager = FindObjectOfType<CustomNetworkManager>();
                mainNetworkManager.SpawnPlayers(); //Spawn Players > Network Manager
            }
            foreach (GameObject playerGO in mainNetworkManager.playablePrefabs)
            {
                Vector3 cameraVector = new Vector3(playerGO.transform.position.x, playerGO.transform.position.y, playerGO.transform.position.z - 10);
                GameObject cameraSpawned = Instantiate(cameraToSpawn, cameraVector, quaternion.identity);
                cameraSpawned.transform.parent = playerGO.transform;
            }
            isActive = true;
            //Subscriptions
            FindObjectOfType<EndTrigger>().TriggerEnterEvent += EndGame;
        }

        public override void EndGame()
        {
            base.EndGame();
            StartCoroutine(EndOfGame(timeToWait, waitTimerToUI));
        }

        private IEnumerator EndOfGame(float waitUIToMain, float waitTimerToUI)
        {
            yield return new WaitForSeconds(waitTimerToUI + 1f); //Wait for UI
            //TODO Show Win UI
            yield return new WaitForSeconds(waitUIToMain); //Wait for exit to main
            //TODO Exit to main menu
        }
        
        ///Pulled Content
        /*
        timer.roundTimer = waitTimerToUI; //Start end of game timer
        GameObject spawnedCountdown = Instantiate(countdownToSpawn, Vector3.zero, quaternion.identity); //Spawn Countdown > Set Time
        timer = spawnedCountdown.GetComponent<Countdown>();
        timer.roundTimer = 100;
        timer.RPCStartRound();
        public GameObject countdownToSpawn;
        */
    }
}