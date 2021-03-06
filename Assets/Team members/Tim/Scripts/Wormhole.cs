using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Wormhole : CommonObject,IGameModeInteractable
{
    public GameObject pairedWormhole;
    public bool isActivated;

    private void OnCollisionEnter(Collision other)
    {
        if (isActivated)
        {
            other.transform.parent.parent.position = pairedWormhole.transform.position + new Vector3(2,0,0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated)
        {
            other.transform.parent.parent.position = pairedWormhole.transform.position + new Vector3(2,0,0);
        }
    }

    public void Activate()
    {
        isActivated = true;
    }
}
