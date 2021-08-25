using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class GravityManager : CommonObject, IGameModeInteractable
    {
        //Private Vars
        private bool isActivated = false;
        
        //Public Vars
        public List<CanGravitate> influencedMasses;//Store the list on the manager to prevent copies
        public List<Gravity> gravityMasses;
        public float areaToAffectGravity;
        
        // Gravity Stuff
        private float gravityArea;
        private float gravityMass;
        private Vector3 directionToObject;
        private float lawOfGravity;
        private Vector3 forceToAdd;
        private float distanceToObject;
        private Vector3 distanceToObjectCapped;
        private float objectSize;
        
        private void Awake()
        {
            CanGravitate.OnCanGravitate += AddToInfluencedMasses;
            CanGravitate.OnStopGravitate += RemoveFromInfluencedMasses;
            Gravity.OnGravityMass += AddToGravityMasses;
            Gravity.OnStopGravityMass += RemoveFromGravityMasses;
        }

        private void FixedUpdate()
        {
            if (isActivated == true)
            {
                if (influencedMasses != null && gravityMasses != null)
                {
                    DoGravity();
                }
            }
        }

        private void DoGravity()
        {
            foreach (Gravity gravRef in gravityMasses)
            {
                if (gravRef.renderer != null)
                {
                    objectSize = gravRef.renderer.bounds.size.magnitude;
                }
                if (gravRef.useObjectSize == false)
                {
                    gravityArea = areaToAffectGravity;
                }
                else if (gravRef.useObjectSize == true)
                {
                    gravityArea = areaToAffectGravity * objectSize + 5;
                }
                foreach (CanGravitate influencedRef in influencedMasses)
                {
                    Rigidbody gravRB = gravRef.rb;
                    Rigidbody influencedRB = influencedRef.rb;
                    influencedRB.centerOfMass = Vector3.zero;
                    directionToObject = gravRB.position - influencedRB.position; //Take the position difference to find the direction
                    distanceToObject = directionToObject.magnitude;
                    if (distanceToObject < gravityArea && gravRef.gameObject != influencedRef.gameObject)
                    {
                        gravityMass = gravRB.mass * influencedRB.mass; //Total Mass
                        distanceToObjectCapped = directionToObject.normalized;
                        lawOfGravity = gravityMass / Mathf.Pow(distanceToObject, 2); //Can use distanceToObject instead but ^ makes it smoother and work better
                        forceToAdd = distanceToObjectCapped * lawOfGravity; //Add that total force in the direction of the object, we use normalized to make the distance general
                        influencedRB.AddForce(forceToAdd); //Add that distance to the rigidbody, this includes direction ect
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

        public void Activate()
        {
            isActivated = true;
        }
    }
}