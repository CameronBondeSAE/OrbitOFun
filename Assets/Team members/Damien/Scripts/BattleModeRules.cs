using System.Collections;
using System.Collections.Generic;
using John;
using LukeBaker;
using UnityEngine;
using Zach;

namespace Damien
{
    public class BattleModeRules : GameModeBase
    {
        private float timeToWait = 5;
        private float waitTimerToUI = 10;
        private CustomNetworkManager mainNetworkManager;
        private Countdown timer;
        
        public GameObject cameraToSpawn;
        public GameObject countdownToSpawn;
        public GameObject sceneToSpawn;
        // Start is called before the first frame update
        void Start()
        {

        }

        public override void Activate()
        {
            base.Activate(); //Activate the mode
            //General Code
            mainNetworkManager = FindObjectOfType<CustomNetworkManager>();
            mainNetworkManager.SpawnPlayers(); //Spawn Players > Network Manager
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
