using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Mirror.Experimental;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AaronMcDougall
{
    public class BezierTest : MonoBehaviour
    {
        public Transform p1;
        public Transform p2;
        public Transform p3;
        public Transform p4;

        [Range(0, 1f)] public float t;
        [Range(0, 1f)] public float speed;

        public bool loopMovement = false;

        private void Start()
        {
            speed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            t += (Time.deltaTime * speed);

            if (t == 1f)
            {
                if (loopMovement == true)
                {
                    t = 0;
                }
            }

        }

        public void OnDrawGizmos()
        {
            Vector2 lerpA = Vector2.Lerp(p1.position, p2.position, t);
            Vector2 lerpB = Vector2.Lerp(p2.position, p3.position, t);
            Vector2 lerpC = Vector2.Lerp(p3.position, p4.position, t);
            Vector2 lerpD = Vector2.Lerp(lerpA, lerpB, t);
            Vector2 lerpE = Vector2.Lerp(lerpB, lerpC, t);
            Vector2 point = Vector2.Lerp(lerpD, lerpE, t);
            
            Gizmos.DrawSphere(Vector2.Lerp(p1.position, p2.position, t), 1f);
            Gizmos.DrawSphere(Vector2.Lerp(p2.position, p3.position, t), 1f);
            Gizmos.DrawSphere(Vector2.Lerp(p3.position, p4.position, t), 1f);

            Gizmos.DrawSphere(lerpD, 0.5f);
            Gizmos.DrawSphere(lerpE, 0.5f);
            Gizmos.DrawSphere(point, 0.1f);
        }
    }
}