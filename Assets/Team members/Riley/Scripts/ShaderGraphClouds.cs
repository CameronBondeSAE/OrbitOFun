using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class ShaderGraphClouds : MonoBehaviour
    {
        private Renderer renderer;
        private double speedDouble;
        private bool isRunning;
        void Start()
        {
            renderer = GetComponent<Renderer>();
        }
        
        void FixedUpdate()
        {
            if (isRunning == false)
            {
                StartCoroutine(ChangeRenderStuff());
            }
        }

        IEnumerator ChangeRenderStuff()
        {
            isRunning = true;
            renderer.material.SetFloat("Clouds", Mathf.Round(Random.Range(8,10)));
            speedDouble = System.Math.Round(Random.Range(-0.2f, 0.0f), 1);
            renderer.material.SetFloat("Speed", (float)speedDouble);
            yield return new WaitForSeconds(5);
            isRunning = false;
        }
    }
}