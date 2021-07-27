using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace John
{
    public class Gravity : MonoBehaviour
    {
        private Rigidbody rb;
        public GravityManager gravityManager;
        private List<GameObject> GravityCentre;

        public Vector3 direction;
        public float distance;
        public float shortestDist = Mathf.Infinity;

        public float force;

        private void Awake()
        {
            GravityCentre = gravityManager.GravityCentres;
            rb = GetComponent<Rigidbody>();
            force = 10;
        }

        private void Update()
        {
            foreach (GameObject centre in GravityCentre)
            {
                Vector3 centrePos = centre.transform.position;
                Vector3 transformPosition = transform.position;
                direction = (centrePos - transformPosition).normalized;
                distance = Mathf.Min(shortestDist, Vector3.Distance(transformPosition, centre.transform.position));
            }
            rb.AddForce((direction/distance) * force);
            
        }
    }
}

