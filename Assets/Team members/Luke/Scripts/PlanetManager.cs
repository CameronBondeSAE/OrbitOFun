using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public List<GravitationalObject> gravitationalObjects;
    
    public float maxPosVelocity;
    public float minNegVelocity;
    private float xVelocity;
    private float yVelocity;
    private float zVelocity;
    private Rigidbody currentRb;

    // Start is called before the first frame update
    void Start()
    {
        gravitationalObjects.AddRange(FindObjectsOfType<GravitationalObject>());
        ApplyRandomVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyRandomVelocity()
    {
        foreach (GravitationalObject obj in gravitationalObjects)
        {
            xVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
            yVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
            zVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
            obj.GetComponent<Rigidbody>().velocity = new Vector3(xVelocity,yVelocity,zVelocity);
        }
    }
}
