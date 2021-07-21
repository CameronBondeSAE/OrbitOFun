using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public List<GravitationalObject> gravitationalObjects;
    public Vector3 currentVelocity;
    public float maxVelocity;
    public float minVelocity;

    // Start is called before the first frame update
    void Start()
    {
        gravitationalObjects.AddRange(FindObjectsOfType<GravitationalObject>());
    }

    // Update is called once per frame
    void Update()
    {
        ApplyRandomVelocity();
    }

    public void ApplyRandomVelocity()
    {
        foreach (GravitationalObject obj in gravitationalObjects)
        {
            currentVelocity = new Vector3(Random.Range(minVelocity, maxVelocity), Random.Range(minVelocity,maxVelocity),0f);
            obj.GetComponent<Rigidbody>().AddForce(currentVelocity);
        }
        //Random.Range()
    }
}
