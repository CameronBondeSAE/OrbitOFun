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
    }
}
