using System.Collections.Generic;
using John;
using LukeBaker;
using Mirror;
using Tom;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private BaseSpawner baseSpawner;

        public CameraBase cameraToSpawn;
        public GameObject sceneToSpawn;
        public Rob.StateBase startingState;
        public PlayerBase localPlayerBase;
        public PlayerArrow localPlayerArrow;
        public List<PlayerBase> leaderboard;


        public override void Activate()
        {
            base.Activate();
            ActivateAllIGameModeInteractables(); // State should do this
            baseSpawner = GetComponent<BaseSpawner>();

            if (networkManager == null)
            {
                networkManager = FindObjectOfType<CustomNetworkManager>();
                networkManager.DespawnPlayers(); //Despawn to clear from last round
                networkManager.SpawnPlayers(); //Spawn Players > Network Manager
            }

            isActive = true;
            // EndTrigger endTrigger = FindObjectOfType<EndTrigger>();
            // endTrigger.PlayerTriggerEnterEvent += EndGame;
            foreach (var player in networkManager.playerInstances)
            {
                baseSpawner.SpawnPlayerBases(player);
            }

            GetComponent<StateManager>().ChangeState(startingState);
            //RpcSetupClient(); // State should do this
        }

        [ClientRpc]
        public void RpcEnableArrowControls()
        {
            if (isServer)
            {
                foreach (var player in networkManager.playerInstances)
                {
                    player.GetComponent<PlayerArrow>().RpcEnableControls();
                }
            }
        }

        [ClientRpc]
        public void RpcDisableControls()
        {
            //Disables arrow controls
            foreach (var player in networkManager.playerInstances)
            {
                player.GetComponent<PlayerArrow>().RpcDisableControls();
            }
        }


        [ClientRpc]
        public void RpcSetupClient()
        {
            //Client Setup Camera
            CameraBase cameraSpawned = Instantiate(cameraToSpawn, Vector3.zero, quaternion.identity)
                .GetComponent<CameraBase>();

            //stop movement on overview
            cameraSpawned.GetComponent<Tom.CameraTracking>().hasRigidbody = false;
            cameraSpawned.AssignTarget(FindObjectOfType<Overview>().transform);
        }

        public override void EndGame()
        {
            base.EndGame();
            networkManager.clientLoadedScene = false;
            networkManager.ServerChangeScene("Core");
        }
    }
}