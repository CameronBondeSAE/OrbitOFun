using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AaronMcDougall
{
    public class CameraFollow : CameraBase
    {
        //object to track
        public Transform targetObject;
        public Rigidbody rb;
        public Vector3 cameraOffset;

        public float smoothSpeed;
        public float velocityOffset = 1.5f;
        public bool hasRigidbody = false;

        //setting target from base class
        public override void AssignTarget(Transform target)
        {
            base.AssignTarget(target);
            targetObject = target;
        }

        private void Start()
        {
            //checking for/getting rigidbody to follow
            if (targetObject.GetComponent<Rigidbody>())
            {
                hasRigidbody = true;
                rb = targetObject.GetComponent<Rigidbody>();
            }
        }

    private void LateUpdate()
        {
            /*if (hasRigidbody)
            {
                //gets values for x & y offsets
                float xVelOffset = rb.velocity.x * velocityOffset;
                float yVelOffset = rb.velocity.y * velocityOffset;

                cameraOffset = new Vector3(xVelOffset, yVelOffset);
            }*/
            
            //stores camera coordinates
            Vector3 cameraPosition = targetObject.position + cameraOffset;
            //lerps camera position for smooth movement
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);
            //moves camera
            transform.position = smoothedPosition;
        }
    }
}