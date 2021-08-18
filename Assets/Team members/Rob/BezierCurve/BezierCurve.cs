using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rob
{



    public class BezierCurve : MonoBehaviour //CommonObject, IGameModeInteractable
    {
        public Transform point1;
        public Transform point2;
        public Transform point3;
        public Transform point4;

        public bool forward;
        public bool backwards;
        private bool playCurve;

        public float speed;

        public AnimationCurve curve;






        private Vector2 curvePoint;

        [Range(0f, 1f)] public float time;


        private void Update()
        {
            if (playCurve)
            {
                /*if (InputSystem.GetDevice<Keyboard>().fKey.wasPressedThisFrame)
                {
                    forward = true;
                }

                if (InputSystem.GetDevice<Keyboard>().bKey.wasPressedThisFrame)
                {

                    backwards = true;

                }*/

                if (forward)
                {
                    //transform.rotation = Quaternion.Euler(point4.position.x, 0, point4.position.z);
                    time += speed * Time.deltaTime;
                    if (time >= 1)
                    {
                        forward = false;
                        time = 1;
                        backwards = true;

                    }
                }

                if (backwards)
                {
                    //transform.rotation = Quaternion.Euler(point4.position.x, 180, point4.position.z);
                    time -= speed * Time.deltaTime;
                    if (time <= 0)
                    {
                        backwards = false;
                        time = 0;
                        forward = true;

                    }
                }

                //transform.position = curvePoint;
            }
        }





        public Vector2 CalculateCurve(float time)
        {
            Vector2 pointA = Vector2.Lerp(point1.position, point2.position, curve.Evaluate(time));
            Vector2 pointB = Vector2.Lerp(point2.position, point3.position, curve.Evaluate(time));
            Vector2 pointC = Vector2.Lerp(point3.position, point4.position, curve.Evaluate(time));
            Vector2 pointD = Vector2.Lerp(pointA, pointB, time);
            Vector2 pointE = Vector2.Lerp(pointB, pointC, time);

            return Vector2.Lerp(pointD, pointE, curve.Evaluate(time));
        }

        public void PlayCurve()
        {
            time = 0;
            playCurve = true;
            forward = true;
        }

        public void Activate()
        {
            PlayCurve();
        }


        public void OnDrawGizmos()
        {
            Handles.DrawBezier(point1.position, point4.position, point2.position, point3.position, Color.black, null,
                2f);

        }
    }
}
