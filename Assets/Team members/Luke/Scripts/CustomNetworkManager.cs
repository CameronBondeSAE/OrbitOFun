using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace LukeBaker
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        public List<string> playerIP;
        public List<GameObject> playerPrefabs;
        public List<NetworkConnection> lobbiedPlayers;

        // TODO old override (find out the difference between OnServerConnect) 
        // public override void OnServerAddPlayer(NetworkConnection conn)
        // {
        //     
        // }

        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);
            playerIP.Add(conn.address);
            //lobbiedPlayers.Add(conn);
        }
        
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);
            playerIP.Remove(conn.address);
            //lobbiedPlayers.Remove(conn);
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
                NetworkServer.AddPlayerForConnection(user, player);
            }
        }
    }
}
