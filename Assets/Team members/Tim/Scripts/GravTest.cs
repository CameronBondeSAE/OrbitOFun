using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravTest : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Vector3 direction;
    public float distance;
    //forceSun = G * (massPlanet * massSun)/d^2;
    private void OnTriggerStay(Collider other)
    {
        Vector3 otherpos = other.transform.position;
        Vector3 transformpos = transform.position;
        direction = (otherpos - transformpos).normalized;
        distance = Vector3.Distance(otherpos, transformpos);
        other.GetComponent<Rigidbody>().AddForce((-direction/distance)*rigidbody.mass);
    }
}
