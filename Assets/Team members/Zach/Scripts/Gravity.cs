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
        //Static list of game objects, newed here so that Unity realises it exists 
        public static List<GameObject> orbitalsStatic = new List<GameObject>();

        public void Awake()
        {
            orbitalsStatic.Add(gameObject);
        }
        
        public void Update()
        {
            foreach (GameObject orbital in orbitalsStatic)
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


