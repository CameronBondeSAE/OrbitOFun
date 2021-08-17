using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace LukeBaker
{
    public class NetworkLobbyPlayer : NetworkBehaviour
    {
        [SyncVar]
        public bool readyToBegin;
        public bool isLobbyplayer;
        [SyncVar]
        public string name;

        //TODO if we want a click for ready
        [Command]
        public void CmdChangeReadyState(bool readyState)
        {
            readyToBegin = readyState;
            CustomNetworkManager room = FindObjectOfType<CustomNetworkManager>();
            if (room != null)
            {
                room.PlayersReadyStateChange();
            }
        }
    }
}
