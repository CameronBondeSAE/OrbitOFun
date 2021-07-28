using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class GravityManager : MonoBehaviour
    {
        //Private Vars

        //Public Vars
        public List<CanGravitate> influencedMasses;//Store the list on the manager to prevent copies
        public List<Gravity> gravityMasses;
        public float areaToAffectGravity;
        
        // Gravity Stuff
        private float gravityMass;
        private Vector3 directionToObject;
        private float lawOfGravity;
        private Vector3 forceToAdd;
        private float distanceToObject;
        private Vector3 distanceToObjectCapped;
        
        private void Awake()
        {
            CanGravitate.OnCanGravitate += AddToInfluencedMasses;
            CanGravitate.OnStopGravitate += RemoveFromInfluencedMasses;
            Gravity.OnGravityMass += AddToGravityMasses;
            Gravity.OnStopGravityMass += RemoveFromGravityMasses;
        }

        private void FixedUpdate()
        {
            if (influencedMasses != null && gravityMasses != null)
            {
                DoGravity();
            }
        }

        private void DoGravity()
        {
            foreach (Gravity gravRef in gravityMasses)
            {
                foreach (CanGravitate influencedRef in influencedMasses)
                {
                    gravityMass = gravRef.rb.mass * influencedRef.rb.mass; //Total Mass
                    directionToObject = gravRef.rb.position - influencedRef.rb.position; //Take the position difference to find the direction
                    distanceToObject = directionToObject.magnitude;
                    if (distanceToObject < areaToAffectGravity)
                    {
                        distanceToObjectCapped = directionToObject.normalized;
                        lawOfGravity = gravityMass / Mathf.Pow(distanceToObject, 2); //Can use distanceToObject instead but ^ makes it smoother and work better
                        forceToAdd = distanceToObjectCapped * lawOfGravity; //Add that total force in the direction of the object, we use normalized to make the distance general
                        influencedRef.rb.AddForce(forceToAdd); //Add that distance to the rigidbody, this includes direction ect
                    }
                }
            }
        }

        private void AddToInfluencedMasses(CanGravitate objectToAdd)
        {
            influencedMasses.Add(objectToAdd);
        }
        private void RemoveFromInfluencedMasses(CanGravitate objectToRemove)
        {
            influencedMasses.Remove(objectToRemove);
        }
        private void AddToGravityMasses(Gravity objectToAdd)
        {
            gravityMasses.Add(objectToAdd);
        }
        private void RemoveFromGravityMasses(Gravity objectToRemove)
        {
            gravityMasses.Remove(objectToRemove);
        }
        
        /// <summary>
        /// Editor Add Velocity Function
        /// </summary>
        public void AddVelocity()
        {
            foreach (CanGravitate objectToGravity in influencedMasses)
            {
                if (objectToGravity != null)
                {
                    Vector3 objectVelocity = objectToGravity.rb.velocity;
                    objectToGravity.rb.velocity = new Vector3(objectVelocity.x, objectVelocity.y + .5f, objectVelocity.z + .5f);
                }
            }
        }
    }
}