using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class BarrierTeleport : MonoBehaviour
    {
        public GameObject oppositeBarrier;
        public Vector3 otherBarrierDirection;

        private void Start()
        {
            otherBarrierDirection = (oppositeBarrier.transform.position - gameObject.transform.position).normalized;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Only support moving physics objects
            if (!other.GetComponent<Rigidbody>())
                return;

            //if (other.GetComponent<Zach.PlayerBase>() != null)
            {
                if (otherBarrierDirection.y > 0 && other.transform.root.GetComponent<Rigidbody>().velocity.y > 0)
                {
                    //If the other barrier is down add up
                    Teleport(other);
                }
                else if (otherBarrierDirection.y < 0 && other.transform.root.GetComponent<Rigidbody>().velocity.y < 0)
                {
                    //If the other barrier is up add down
                    Teleport(other);
                }
            }
        }

        void Teleport(Collider other)
        {
            other.transform.root.transform.position = new Vector3(other.transform.root.transform.position.x, oppositeBarrier.transform.position.y, 0);
        }
    }
}