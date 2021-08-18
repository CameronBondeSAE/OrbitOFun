using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rob
{


    public class BezierMovement : MonoBehaviour
    {
        private BezierCurve bezier;
        public Transform objectCurving;

        private void Awake()
        {
            bezier = GetComponent<BezierCurve>();
        }

        private void Update()
        {
            Vector2 currentPoint = bezier.CalculateCurve(bezier.curve.Evaluate(bezier.time));
            objectCurving.position = currentPoint;

            Vector2 dir;

            if (bezier.backwards)
            {
                dir = currentPoint - bezier.CalculateCurve(bezier.curve.Evaluate(bezier.time - Time.deltaTime));
            }
            else
            {
                dir = currentPoint - bezier.CalculateCurve(bezier.curve.Evaluate(bezier.time + Time.deltaTime));
            }

            objectCurving.right = dir;
        }


    }
}
