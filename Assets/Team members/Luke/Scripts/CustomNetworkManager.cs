using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace LukeBaker
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        //replace with lobbyPlayer
        public List<NetworkConnection> playersConnected;
        public List<string> lobbyUser;

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            lobbyUser.Add(conn.address);
            
            playersConnected.Add(conn);
        }

        //TODO to be called
        public void OnServerSpawnPlayers()
        {
            //start game button or event???
            foreach (NetworkConnection connection in playersConnected)
            {
                Transform startPos = GetStartPosition();
                GameObject player = startPos != null
                    ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                    : Instantiate(playerPrefab);

                // instantiating a "Player" prefab gives it the name "Player(clone)"
                // => appending the connectionId is WAY more useful for debugging!
                player.name = $"{playerPrefab.name} [connId={connection.connectionId}]";
                NetworkServer.AddPlayerForConnection(connection, player);
            }
        }
    }
}
