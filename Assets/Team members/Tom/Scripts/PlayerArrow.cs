using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tom
{
    public class PlayerArrow : NetworkBehaviour
    {
        public float rotationSpeed = 180f; // How many degrees per second
        public float rotationLimit = 45f;
        private float startingAngle;
        private ZachsPlayerActions zachsPlayerActions;
        public Vector3 rotateVelocity;
        
        private float direction; // Set this to the input axis

        void Awake()
        {
            zachsPlayerActions = new ZachsPlayerActions();
            zachsPlayerActions.Enable();
        }

        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();
            startingAngle      = transform.eulerAngles.z;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                // if (InputSystem.GetDevice<Keyboard>().aKey.isPressed)
                // {
                //     transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
                // }
                //
                // if (InputSystem.GetDevice<Keyboard>().dKey.isPressed)
                // {
                //     transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
                // }
                
                // Replace above with this function when using new Input System
                // Set direction to axis input
                transform.Rotate(Vector3.forward * rotationSpeed * -direction * Time.deltaTime);

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
        }


        public void EnableControls()
        {
            //todo refactor to work with system wide new input system

            zachsPlayerActions.GeneralMovement.Rotate.started += RotateOnPerformed;
            zachsPlayerActions.GeneralMovement.Rotate.canceled += RotateOnPerformed;
        }

        public void DisableControls()
        {
            //todo refactor to work with system wide new input system
            zachsPlayerActions.GeneralMovement.Rotate.started -= RotateOnPerformed;
            zachsPlayerActions.GeneralMovement.Rotate.canceled -= RotateOnPerformed;
        }
        private void RotateOnPerformed(InputAction.CallbackContext obj)
        {
            direction = obj.ReadValue<float>();
            // rotateVelocity = new Vector3(0, 0, -15 * obj.ReadValue<float>());
        }

        public Vector3 GetEulerAngles()
        {
            return transform.eulerAngles;
        }
    }
}