using System.Collections;
using System.Collections.Generic;
using Luke;
using UnityEngine;

namespace John
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private CustomNetworkManager networkManager = null;
        
        public void HostLobby()
        {
            networkManager.StartHost();
        
            //toggle UI from menu to lobby UI
        }
    }
    
}

