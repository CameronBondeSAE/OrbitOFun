using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class NetworkLobbyPlayer : NetworkBehaviour
    {
        public bool readyToBegin;
        public string name;
        
        [Command]
        public void CmdChangeReadyState(bool readyState)
        {
            readyToBegin = readyState;
            CustomNetworkManager room = FindObjectOfType<CustomNetworkManager>();
            if (room != null)
            {
                room.PlayersReadied();
            }
        }
    }
}
