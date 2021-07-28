using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Luke
{
    public class CustomNetworkManager : NetworkManager
    {
        //Variables
        public List<GameObject> players;
        // TODO needs to reference gamemodes starting positions
        public List<Transform> startingPositions;

        //References

        
        //Events
        

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            //base.OnServerAddPlayer(conn);
            
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
