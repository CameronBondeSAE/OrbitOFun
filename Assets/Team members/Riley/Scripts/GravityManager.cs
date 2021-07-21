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
        public List<CanGravitate> listOfObjects;//Store the list on the manager to prevent copies

        private void Awake()
        {
            CanGravitate.OnCanGravitate += AddObjectToList;
            CanGravitate.OnStopGravitate += RemoveObjectFromList;
        }

        private void AddObjectToList(CanGravitate objectToAdd)
        {
            listOfObjects.Add(objectToAdd);
        }
        private void RemoveObjectFromList(CanGravitate objectToRemove)
        {
            listOfObjects.Remove(objectToRemove);
        }

        public void AddVelocity()
        {
            foreach (CanGravitate objectToGravity in listOfObjects)
            {
                if (objectToGravity != null)
                {
                    Vector3 objectVelocity = objectToGravity.objectsRigidbody.velocity;
                    objectToGravity.objectsRigidbody.velocity = new Vector3(objectVelocity.x, objectVelocity.y + .5f, objectVelocity.z + .5f);
                }
            }
        }
    }
}