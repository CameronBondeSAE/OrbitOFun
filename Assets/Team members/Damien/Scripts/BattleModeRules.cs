using System.Collections.Generic;
using AaronMcDougall;
using John;
using LukeBaker;
using Mirror;
using RileyMcGowan;
using Tom;
using Unity.Mathematics;
using Unity.VisualScripting;
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
        private Vector3 spawnPos;
        private GameObject spawnedBase;

        public GameObject playerBasePiece;
        public CameraBase cameraToSpawn;
        public GameObject sceneToSpawn;
        public Rob.StateBase startingState;
        public PlayerBase localPlayerBase;
        public PlayerArrow localPlayerArrow;
        public List<PlayerBase> leaderboard;
        public GameObject meteor;
        public int baseCount;
        public List<GameObject> bases;


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
                RpcSpawnPlayerBases(player);
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
        public void RpcFireMeteor()
        {
            if (isServer)
            {
                foreach (GameObject player in networkManager.playerInstances)
                {
                    GameObject playerArrow = player.GetComponent<PlayerArrow>().gameObject;
                    Vector3 spawnPos = player.GetComponentInChildren<meteorSpawn>().transform.position;
                    GameObject spawnedMeteor = Instantiate(meteor, spawnPos,
                        playerArrow.transform.localRotation);
                    NetworkServer.Spawn(spawnedMeteor);
                    spawnedMeteor.GetComponent<Rigidbody>().AddRelativeForce(0, 300, 0);
                }
            }
        }


        void Death(Health defenceBase)
        {
            baseCount--;
            defenceBase.deathEvent -= Death;
            if (isLocalPlayer)
            {
                DisableControls();
            }
        }


        public void DisableControls()
        {
            //Disables arrow controls
            foreach (var player in networkManager.playerInstances)
            {
                player.GetComponent<PlayerArrow>().RpcDisableControls();
            }
        }


        [ClientRpc]
        public void RpcSpawnPlayerBases(GameObject player)
        {
            if (isServer)
            {
                spawnPos = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y,
                    player.transform.localPosition.z);
                spawnedBase = Instantiate(playerBasePiece, spawnPos, player.transform.localRotation);
                NetworkServer.Spawn(spawnedBase);
                bases.Add(spawnedBase);
                baseCount = bases.Count;
                spawnedBase.GetComponent<Health>().deathEvent += Death;
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
            Debug.Log("Game Has Ended");
        }
    }
}