using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Gravity : MonoBehaviour
    {
        //Private Vars
        private Rigidbody rb;
        private GravityManager gravityManager;
        
        //Public Vars
        
        
        // Gravity Stuff
        private float gravityMass;
        private Vector3 directionToObject;
        private float lawOfGravity;
        private Vector3 forceToAdd;
        private float distanceToObject;
        private Vector3 distanceToObjectCapped;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            gravityManager = FindObjectOfType<GravityManager>();
        }

        private void FixedUpdate()
        {
            foreach (CanGravitate objectToGravity in gravityManager.listOfObjects)
            {
                if (objectToGravity != null)
                {
                    DoGravity(objectToGravity);
                }
            }
        }

        private void DoGravity(CanGravitate objectToGravity)
        {
            gravityMass = rb.mass * objectToGravity.objectsRigidbody.mass; //Total Mass
            directionToObject = rb.position - objectToGravity.objectsRigidbody.position; //Take the position difference to find the direction
            distanceToObject = directionToObject.magnitude;
            distanceToObjectCapped = directionToObject.normalized;
            lawOfGravity = gravityMass / Mathf.Pow(distanceToObject, 2); //Can use distanceToObject instead but ^ makes it smoother and work better
            forceToAdd = distanceToObjectCapped * lawOfGravity; //Add that total force in the direction of the object, we use normalized to make the distance general
            objectToGravity.objectsRigidbody.AddForce(forceToAdd); //Add that distance to the rigidbody, this includes direction ect
        }
    }
}