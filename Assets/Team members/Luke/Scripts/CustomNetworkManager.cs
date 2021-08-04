using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace LukeBaker
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        // TODO needs to reference each game modes starting positions??
        public List<Transform> startingPositions;
        public List<NetworkConnection> players;

        //References
        // TODO lobby ref

        //Events
        

        public override void OnStartServer()
        {
            base.OnStartServer();
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            players.Add(conn);
        }

        public void OnServerSpawnPlayers(NetworkConnection conn)
        {
            //start game button or event???
            foreach (NetworkConnection connection in players)
            {
                Transform startPos = GetStartPosition();
                GameObject player = startPos != null
                    ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                    : Instantiate(playerPrefab);

                // instantiating a "Player" prefab gives it the name "Player(clone)"
                // => appending the connectionId is WAY more useful for debugging!
                player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
                NetworkServer.AddPlayerForConnection(conn, player);
            }
        }
    }
}
