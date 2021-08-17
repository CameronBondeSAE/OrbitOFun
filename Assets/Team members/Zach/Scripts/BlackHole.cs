using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zach
{
    public class BlackHole : MonoBehaviour
    {
        public Vector3 gizmosSize;
        public float xLength;
        public float yHeight;
        
        private void OnCollisionEnter(Collision other)
        {
            other.transform.position = new Vector3(Random.Range(-xLength/2f, xLength/2f), Random.Range(-yHeight/2f, yHeight/2f), 0);
        }

        private void OnDrawGizmos()
        {
            gizmosSize = new Vector3(xLength, yHeight);
            Gizmos.DrawCube(transform.position,gizmosSize);
        }
    }
}
