using System.Collections;
using System.Collections.Generic;
using AaronMcDougall;
using John;
using LukeBaker;
using Mirror;
using Tom;
using Unity.Mathematics;
using UnityEngine;
using Zach;
using StateManager = Rob.StateManager;

namespace Damien
{
    public class BattleModeRules : GameModeBase
    {
        private float timeToWait = 5;
        private float waitTimerToUI = 10;
        private CustomNetworkManager networkManager;
        private Countdown timer;
        private GameObject endGoal;
        private bool isActive = false;
        private int maxPlayers = 4;

        public CameraBase cameraToSpawn;
        public GameObject sceneToSpawn;
        public Rob.StateBase startingState;
        public PlayerBase localPlayerBase;
        public PlayerArrow localPlayerArrow;
        public List <PlayerBase> leaderboard;
        
        
        public override void Activate()
        {
            base.Activate();
            ActivateAllIGameModeInteractables();

            if (networkManager == null)
            {
                networkManager = FindObjectOfType<CustomNetworkManager>();
                networkManager.SpawnPlayers(); //Spawn Players > Network Manager
            }
            isActive = true;
            
            // EndTrigger endTrigger = FindObjectOfType<EndTrigger>();
            // endTrigger.PlayerTriggerEnterEvent += EndGame;
            
            localPlayerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>(); //Controls for player
            localPlayerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>(); //Controls for arrows
            GetComponent<StateManager>().ChangeState(startingState);
            RpcSetupClient();
            // RpcEnableLocalPlayerControls();
        }

        // [ClientRpc]
        // public void RpcEnableArrowControls()
        // {
        //     ControlNullCheck();
        //     //Enable player controls
        //     localPlayerBase.DisableControls();
        //     //Enable arrow controls
        //     localPlayerArrow.RpcEnableControls();
        // }
        //
        // [ClientRpc]
        // public void RpcEnableLocalPlayerControls()
        // {
        //     PlayerBase playerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>();
        //     playerBase.enabled = false;
		      //
        //     PlayerArrow playerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>();
        //     // playerArrow.EnableControls();
        //     playerArrow.enabled = true;
        //     
        // }
        //
        // [ClientRpc]
        // public void RpcDisableControls()
        // {
        //     ControlNullCheck();
        //     //Disables arrow controls
        //     localPlayerArrow.DisableControls();
        // }
        //
        // private void ControlNullCheck()
        // {
        //     if (localPlayerBase == null)
        //     {
        //         localPlayerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>(); //Controls for player
        //     }
        //
        //     if (localPlayerArrow == null)
        //     {
        //         localPlayerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>(); //Controls for arrows
        //     }
        // }
        
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

        public override void EndGame()
        {
            base.EndGame();
            StartCoroutine(EndGame(timeToWait, waitTimerToUI));
        }

        private IEnumerator EndGame(float waitUIToMain, float waitTimerToUI)
        {
            yield return new WaitForSeconds(waitTimerToUI + 1f); //Wait for UI
            //TODO Show Win UI
            yield return new WaitForSeconds(waitUIToMain); //Wait for exit to main
            //TODO Exit to main menu
        }
    }
}