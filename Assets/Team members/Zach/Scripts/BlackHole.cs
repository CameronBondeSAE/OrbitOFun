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
        public float xRange;
        public float yRange;


        public void Update()
        {
            xRange = Random.Range(-xLength/2f, xLength);
            yRange = Random.Range(-yHeight, yHeight);
        }

        public void OnCollisionEnter(Collision other)
        {
            other.transform.position = new Vector3(xRange, yRange, 0);
        }

        private void OnDrawGizmos()
        {
            gizmosSize = new Vector3(xLength, yHeight);
            Gizmos.DrawCube(transform.position,gizmosSize);
        }
    }
}
