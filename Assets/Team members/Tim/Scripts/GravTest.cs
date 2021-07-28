using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravTest : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 direction;
    public float distance;
    // float G = tbc numberf;
    //forceSun = G * (rigidbodyMass * other.rigidbodyMass)/distance^2;
    private void OnTriggerStay(Collider other)
    {
        float rigidbodyMass = rigidbody.mass;
        Vector3 otherpos = other.transform.position;
        Vector3 transformpos = transform.position;
        direction = (otherpos - transformpos).normalized;
        distance = Vector3.Distance(otherpos, transformpos);
        other.GetComponent<Rigidbody>().AddForce((-direction/distance)*rigidbodyMass);
    }
}
