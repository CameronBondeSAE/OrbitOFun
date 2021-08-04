using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Tim
{
    public class GravTest : MonoBehaviour
    {
        public Rigidbody rigidbody;
        private Vector3 direction;
        private float distance;
        public float g = 5f;
        private float planetGrav;
        private Vector3 grav;
        private Rigidbody otherRb;
        private float rigidbodyMass;
        private Rigidbody otherRB;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            //Gravity();
        }

        private void Gravity()
        {
            //var otherObj = GetComponent<>();
            otherRB = GetComponent<Rigidbody>();
            rigidbodyMass = rigidbody.mass;
            Vector3 otherpos = otherRB.transform.position;
            Vector3 transformpos = transform.position;
            direction = (otherpos - transformpos).normalized;
            distance = Vector3.Distance(otherpos, transformpos);
            //otherObj.GetComponent<Rigidbody>().AddForce((-direction/distance)*rigidbodyMass);
            otherRB.AddForce((-direction/distance)*rigidbodyMass);
            planetGrav = g * (rigidbody.mass * otherRB.mass)/Mathf.Pow(distance,2);
        }


        private void OnTriggerStay(Collider other)
        {
            otherRB = other.GetComponent<Rigidbody>();
            rigidbodyMass = rigidbody.mass;
            Vector3 otherpos = other.transform.position;
            Vector3 transformpos = transform.position;
            direction = (otherpos - transformpos).normalized;
            distance = Vector3.Distance(otherpos, transformpos);
            planetGrav = g * (rigidbody.mass * otherRB.mass)/Mathf.Pow(distance,2);
            //other.GetComponent<Rigidbody>().AddForce((-direction/distance)*rigidbodyMass);
            other.GetComponent<Rigidbody>().AddForce((-direction/distance)*planetGrav);
            
        }
        
        
    }
}

