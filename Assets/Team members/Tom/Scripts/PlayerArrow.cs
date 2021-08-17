using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tom
{
    public class PlayerArrow : MonoBehaviour
    {
        public float rotationSpeed = 180f; // How many degrees per second
        public float rotationLimit = 45f;
        private float startingAngle;
        
        private float direction; // Set this to the input axis

        private void Start()
        {
            startingAngle = transform.eulerAngles.z;
        }

        // Update is called once per frame
        void Update()
        {
            if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
            {
                transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            }

            if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
            {
                transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
            }
            
            // Replace above with this function when using new Input System
            // Set direction to axis input
            //transform.Rotate(Vector3.forward * rotationSpeed * direction * Time.deltaTime);
            
            float currentRotation = transform.eulerAngles.z;
            // HACK
            // Counters eulerAngles clamping between 0 and 360
            if (currentRotation > 180f && startingAngle - rotationLimit < 0)
            {
                currentRotation -= 360f;
            }
            currentRotation = Mathf.Clamp(currentRotation, startingAngle - rotationLimit,
                startingAngle + rotationLimit);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotation);
        }

        public Vector3 GetEulerAngles()
        {
            return transform.eulerAngles;
        }
    }
}