using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Wormhole : MonoBehaviour
{
    public GameObject pairedWormhole;
    public float offset = 1f;
    public Rigidbody rigidbody;
    private Vector3 direction;
    private float distance;

    private void OnTriggerEnter(Collider other)
    {
        float dotProduct = Vector3.Dot(other.GetComponent<Rigidbody>().velocity.normalized, transform.forward);

        if (dotProduct < 0)
        {
            float distance = Vector3.Distance(transform.position, pairedWormhole.transform.position) - offset;
            other.transform.position += transform.forward * distance;
        }
    }
    
}
