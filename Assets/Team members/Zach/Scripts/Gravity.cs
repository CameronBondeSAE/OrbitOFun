using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class Gravity : MonoBehaviour
    {
        //original version of my gravity script
        public Rigidbody rigidbody;
        
        public Vector3 direction;
        public Vector3 gravityForce;
        public float distance;
        public float maxDistance;
        //New version of my gravity script
        public List<GameObject> orbitals;
        public MoonSpawner moonSpawner;

        public void Start()
        {
            moonSpawner = FindObjectOfType<MoonSpawner>();
            orbitals = moonSpawner.orbitals;
        }

        public void Update()
        {
            foreach (GameObject orbital in orbitals)
            {
                if (orbital != this.gameObject)
                {
                    Vector3 otherPosition = orbital.transform.position;
                    Vector3 transformPosition = transform.position;
                    direction = (otherPosition - transformPosition).normalized;
                    distance = Vector3.Distance(otherPosition, transformPosition);
                    gravityForce = (-direction / distance) * rigidbody.mass;
                    orbital.GetComponent<Rigidbody>().AddForce(gravityForce);
                    /*if (distance <= maxDistance)
                    {
                        
                    }*/
                }
            }
        }
    }
}


