using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWrangler : MonoBehaviour
{
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		// Set the Blackboard variables from C#
        renderer.material.SetFloat("Scale", Random.Range(0.1f,100f));        
    }
}
