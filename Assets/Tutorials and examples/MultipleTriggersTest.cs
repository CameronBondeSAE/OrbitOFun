using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTriggersTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Triggered! : Go = "+gameObject.name);
	}

	void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collided"+gameObject.name);
	}
}
