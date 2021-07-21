using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class Gravity : MonoBehaviour
    {
        public Rigidbody rigidbody;
        
        public Vector3 direction;
        public Vector3 gravityForce;
        public float distance;

        private void OnTriggerStay(Collider other)
        {
            Vector3 otherPosition = other.transform.position;
            Vector3 transformPosition = transform.position;
            direction = (otherPosition - transformPosition).normalized;
            distance = Vector3.Distance(otherPosition, transformPosition);
            gravityForce = (-direction / distance) * rigidbody.mass;
            other.GetComponent<Rigidbody>().AddForce(gravityForce);
        }
    }
}


