using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        public List<string> playerIP;
        public List<GameObject> playerPrefabs;
        public NetworkLobbyPlayer roomPlayer;
        public List<NetworkConnection> lobbiedPlayers = new List<NetworkConnection>();
        
        [Tooltip("List of Room Player objects")]
        public List<NetworkLobbyPlayer> roomSlots = new List<NetworkLobbyPlayer>();
        public int currentPlayers;
        public int readyPlayers;
        public bool allPlayersReady;
        

        // TODO old override (find out the difference between OnServerConnect) 
        // public override void OnServerAddPlayer(NetworkConnection conn)
        // {
        //     
        // }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            playerIP.Add(conn.address);
            lobbiedPlayers.Add(conn);

            //spawn room player
            if (roomPlayer != null)
            {
                Instantiate(roomPlayer);
                NetworkServer.AddPlayerForConnection(conn, roomPlayer.gameObject);
                currentPlayers++;
                roomSlots.Add(roomPlayer);
            }
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            playerIP.Remove(conn.address);
            lobbiedPlayers.Remove(conn);
            currentPlayers--;
            roomSlots.Remove(roomPlayer);
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

                playerPrefabs.Add(playerPrefab);

                // instantiating a "Player" prefab gives it the name "Player(clone)"
                // => appending the connectionId is WAY more useful for debugging!
                player.name = $"{playerPrefab.name} [connId={user.connectionId}]";

                //TODO change to already existing connection to change into an in Game playable object
                //NetworkServer.AddPlayerForConnection(user, player);
            }
        }

        public void PlayersReadied()
        {
            int CurrentPlayers = 0;
            int ReadyPlayers = 0;

            foreach (NetworkLobbyPlayer player in roomSlots)
            {
                if (player != null)
                {
                    CurrentPlayers++;
                    if (player.readyToBegin)
                        ReadyPlayers++;
                }
            }

            //TODO to be used to enable the button to start the game
            if (CurrentPlayers == ReadyPlayers)
            {
                allPlayersReady = true;
            }

            else
            {
                allPlayersReady = false;
            }
        }
    }
}