using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class BarrierTeleport : MonoBehaviour
    {
        public GameObject oppositeBarrier;
        public Vector3 direction;

        private void Start()
        {
            direction = gameObject.transform.position - oppositeBarrier.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.GetComponent<Zach.PlayerBase>() != null)
            {
                if (direction.y > 0)
                {
                    //If the other barrier is down add up
                    other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                        oppositeBarrier.transform.position.y + 5f, oppositeBarrier.transform.position.z);
                }
                else if (direction.y < 0)
                {
                    //If the other barrier is up add down
                    other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x,
                        oppositeBarrier.transform.position.y - 5f, oppositeBarrier.transform.position.z);
                }
            }
        }
    }
}