using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

namespace Tom
{
    public class SlowField : MonoBehaviour
    {
        public float slowSpeed = 1f;
        private float storedSpeed;
        
        private void OnTriggerEnter(Collider other)
        {
            PlayerBase player = other.GetComponentInParent<PlayerBase>();

            if (player != null)
            {
                storedSpeed = player.maxSpeed;
                player.maxSpeed = slowSpeed;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PlayerBase player = other.GetComponentInParent<PlayerBase>();

            if (player != null)
            {
                player.maxSpeed = storedSpeed;
            }
        }
    }
}