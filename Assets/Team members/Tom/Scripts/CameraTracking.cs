using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class CameraTracking : CameraBase
    {
        public Transform trackedTarget;
        public float zOffset = -10f;
        private Vector3 offset;
        public float smoothTime = 10f;
        public float velocityMultiplier = 1f;
        public float zoomMultiplier = 2f;
        public bool hasRigidbody = false;
        private Rigidbody rb;
        
        public override void AssignTarget(Transform target)
        {
            base.AssignTarget(target);

            trackedTarget = target;

            if (target.GetComponent<Rigidbody>())
            {
                hasRigidbody = true;
                rb = target.GetComponent<Rigidbody>();
            }
        }

        private void Start()
        {
            if (hasRigidbody)
            {
                rb = trackedTarget.GetComponent<Rigidbody>();
            }
        }

        private void LateUpdate()
        {
            if (hasRigidbody)
            {
                float xVelocity = rb.velocity.x * velocityMultiplier;
                float yVelocity = rb.velocity.y * velocityMultiplier;
                float magnitude = rb.velocity.magnitude * zoomMultiplier;
                
                offset = new Vector3(xVelocity, yVelocity, zOffset - magnitude);
            }
        }

        private void FixedUpdate()
        {
            if (trackedTarget != null)
            {
                transform.position = Vector3.Lerp(transform.position, trackedTarget.position + offset, Time.deltaTime * smoothTime);
            }
        }
    }
}