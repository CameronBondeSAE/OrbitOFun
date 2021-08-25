using System;
using System.Collections;
using System.Collections.Generic;
using AaronMcDougall;
using John;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using Zach;
using LukeBaker;
using Tom;
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
        public CameraBase cameraToSpawn;
        public GameObject sceneToSpawn;
        public AaronMcDougall.StateBase startingState;
        public PlayerBase localPlayerBase;
        public PlayerArrow localPlayerArrow;
        public List <PlayerBase> leaderboard;
        
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
            isActive = true;
            //Subscriptions
            //if ()
            {
                EndTrigger endTrigger = FindObjectOfType<EndTrigger>();
                endTrigger.TriggerEnterEvent += EndGame;
            }
            localPlayerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>(); //Controls for player
            localPlayerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>(); //Controls for arrows
            GetComponent<RaceModeStateManager>().ChangeState(startingState);
            RpcSetupClient(); //TODO can be changed to states managed
        }

        [ClientRpc]
        public void RpcEnableArrowControls()
        {
            ControlNullCheck();
            //Enable player controls
            localPlayerBase.DisableControls();
            //Enable arrow controls
            localPlayerArrow.EnableControls();
        }
        
        [ClientRpc]
        public void RpcEnablePlayerControls()
        {
            ControlNullCheck();
            //Disable arrow controls
            localPlayerArrow.DisableControls();
            //Enable player controls
            localPlayerBase.EnableControls();
        }
        
        [ClientRpc]
        public void RpcDisableAllControls()
        {
            ControlNullCheck();
            //Disable player controls
            localPlayerBase.DisableControls();
            //Disable arrow controls
            localPlayerArrow.DisableControls();
        }
        
        [ClientRpc]
        public void RpcSetupClient()
        {
            //Client Setup Camera
            NetworkIdentity player = NetworkClient.localPlayer;
            CameraBase cameraSpawned = Instantiate(cameraToSpawn, Vector3.zero, quaternion.identity).GetComponent<CameraBase>();
            cameraSpawned.AssignTarget(player.gameObject.transform);
            //
        }

        public void FreezePlayer(PlayerBase playerToFreeze)
        {
            playerToFreeze.GetComponent<Rigidbody>().velocity    = Vector3.zero;
            playerToFreeze.GetComponent<Rigidbody>().isKinematic = true;
        }
        public void UnFreezePlayer(PlayerBase playerToFreeze)
        {
            // playerToFreeze.GetComponent<Rigidbody>().velocity    = Vector3.zero;
            playerToFreeze.GetComponent<Rigidbody>().isKinematic = false;
        }

        private void ControlNullCheck()
        {
            if (localPlayerBase == null)
            {
                Debug.LogError(this + " does not hold a reference for PlayerBase, attempting to find.");
                localPlayerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>(); //Controls for player
            }

            if (localPlayerArrow == null)
            {
                Debug.LogError(this + " does not hold a reference for PlayerArrow, attempting to find.");
                localPlayerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>(); //Controls for arrows
            }
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