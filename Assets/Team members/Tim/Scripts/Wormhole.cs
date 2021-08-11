using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public GameObject pairedWormhole;


    private void OnCollisionEnter(Collision other)
    {
        other.transform.position = pairedWormhole.transform.position + new Vector3(2,0,0);
    }
    //physics.overlap
}
