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
        public List<User> lobbiedPlayers;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            playerIP.Add(conn.address);
            
            //lobbiedPlayers.Add();
        }

        //TODO to be called
        public void OnServerSpawnPlayers()
        {
            //start game button or event???
            foreach (User user in lobbiedPlayers)
            {
                Transform startPos = GetStartPosition();
                GameObject player = startPos != null
                    ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                    : Instantiate(playerPrefab);

                // instantiating a "Player" prefab gives it the name "Player(clone)"
                // => appending the connectionId is WAY more useful for debugging!
                player.name = $"{playerPrefab.name} [connId={user.networkConnection.connectionId}]";
                NetworkServer.AddPlayerForConnection(user.networkConnection, player);
            }
        }
    }
}
