using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Mirror.Experimental;
using Unity.VisualScripting;
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

        public Transform ship;
        public Vector2 point;

        [Range(0, 1f)] public float t;
        [Range(0, 1f)] public float speed;

        public bool movement = false;
        public bool reverseMovement = false;

        //different movement modes to select from
        public enum PlayType
        {
            SinglePlay,
            Loop,
            PingPong
        }

        //to be totally honest I took inspiration for this from Tom
        public PlayType playType;


        void Update()
        {
            //determines movement mode, plays animation accordingly
            if (reverseMovement && playType == PlayType.PingPong)
            {
                t -= Time.deltaTime * speed;
            }
            else if(movement)
            {
                t += (Time.deltaTime * speed);
            }
            
            if (reverseMovement && t <= 0)
            {
                t = 0;
                reverseMovement = false;
                PlayMovement();
            }
            
            if (t >= 1)
            {
                switch (playType)
                {
                    case PlayType.SinglePlay:
                    {
                        t = 0;
                        speed = 0;
                        movement = false;
                        break;
                    }
                    case PlayType.Loop:
                    {
                        t = 0;
                        break;
                    }
                    case PlayType.PingPong:
                    {
                        t = 1;
                        reverseMovement = true;
                        break;
                    }
                }
            }
            
            //setting lerps
            Vector2 lerpA = Vector2.Lerp(p1.position, p2.position, t);
            Vector2 lerpB = Vector2.Lerp(p2.position, p3.position, t);
            Vector2 lerpC = Vector2.Lerp(p3.position, p4.position, t);
            Vector2 lerpD = Vector2.Lerp(lerpA, lerpB, t);
            Vector2 lerpE = Vector2.Lerp(lerpB, lerpC, t);
            
            point = Vector2.Lerp(lerpD, lerpE, t);
            ship.position = point;

        }

        public void OnDrawGizmos()
        {
            Gizmos.DrawSphere(point, 0.1f);
        }

        public void PlayMovement()
        {
            movement = true;
        }
    }
}