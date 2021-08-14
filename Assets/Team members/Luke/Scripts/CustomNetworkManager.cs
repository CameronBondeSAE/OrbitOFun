using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        public List<string> playerIP;
        public List<GameObject> playablePrefabs;
        public List<NetworkConnection> lobbiedPlayers = new List<NetworkConnection>();
        
        [Tooltip("List of Room Player objects")]
        public List<NetworkLobbyPlayer> roomSlots = new List<NetworkLobbyPlayer>();
        public int currentPlayers;
        public int readyPlayers;
        public bool allPlayersReady;
        
        [Header("Room")]
        [SerializeField] private NetworkLobbyPlayer roomPlayerPrefab = null;

        //event
        public event Action PlayersReadiedEvent;

        // TODO old override (find out the difference between OnServerConnect) 
        // public override void OnServerAddPlayer(NetworkConnection conn)
        // {
        //     
        // }

        private void OnServerInitialized()
        {
            currentPlayers = 0;
            readyPlayers = 0;
        }

        public override void OnServerConnect(NetworkConnection conn)
        {
            //connecting the ip of client and connection to a list of lobbied players
            base.OnServerConnect(conn);
            playerIP.Add(conn.address);
            lobbiedPlayers.Add(conn);

            //instantiating a roomPlayer (non-playable state), then slotting them into a list of roomSlot that holds the base
            NetworkLobbyPlayer roomPlayerInstance = Instantiate(roomPlayerPrefab);
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
            currentPlayers++;
            roomSlots.Add(roomPlayerInstance);
        }

        //Removal when disconnecting
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            playerIP.Remove(conn.address);
            lobbiedPlayers.Remove(conn);
            currentPlayers--;
            roomSlots.Remove(roomPlayerPrefab);
        }

        //TODO to be called by gamemodes
        public void SpawnPlayers()
        {
            //start game button or event???
            foreach (NetworkConnection user in lobbiedPlayers)
            {
                Transform startPos = GetStartPosition();
                GameObject player = startPos != null
                    ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                    : Instantiate(playerPrefab);

                playablePrefabs.Add(playerPrefab);

                // instantiating a "Player" prefab gives it the name "Player(clone)"
                // => appending the connectionId is WAY more useful for debugging!
                player.name = $"{playerPrefab.name} [connId={user.connectionId}]";

                //TODO change to already existing connection to change into an in Game playable object
                //NetworkServer.AddPlayerForConnection(user, player);
            }
        }

        //when players have clicked the ready button
        public void PlayersReadyStateChange()
        {
            foreach (NetworkLobbyPlayer player in roomSlots)
            {
                if (player != null)
                {
                    if (player.readyToBegin)
                    {
                        readyPlayers++;
                    }
                }
            }
        }

        //TODO the start button needs to be able to call this or have this check constantly???
        public void AllPlayersReadied()
        {
            //TODO used to enable the button start game
            if (currentPlayers == readyPlayers)
            {
                allPlayersReady = true;
                PlayersReadiedEvent?.Invoke();
            }

            else
            {
                allPlayersReady = false;
                Debug.Log("Players not ready");
            }
        }
    }
}