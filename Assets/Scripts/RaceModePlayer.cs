using Mirror;
using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEngine;
using Zach;

public class RaceModePlayer : NetworkBehaviour
{
    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Debug.Log("Player islocalplayer = "+isLocalPlayer);

        GetComponentInChildren<PlayerBase>().isLocalPlayerHack = isLocalPlayer;
        GetComponentInChildren<PlayerArrow>().isLocalPlayerHack = isLocalPlayer;
    }
}

