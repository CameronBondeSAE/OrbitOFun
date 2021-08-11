using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    [RequireComponent(typeof(BezierCurve))]
    public class BezierMovement : MonoBehaviour
    {
        private BezierCurve bezier;
        public Transform curvingObject;

        private void Awake()
        {
            bezier = GetComponent<BezierCurve>();
        }

        private void Update()
        {
            Vector2 currentPoint = bezier.CalculateCurvePoint(bezier.curve.Evaluate(bezier.curveTime));
            curvingObject.position = currentPoint;

            // Sets forward point in 2D to direction curve is going
            Vector2 direction;
            if (bezier.reversing)
            {
                direction = currentPoint - bezier.CalculateCurvePoint(bezier.curve.Evaluate(bezier.curveTime + Time.deltaTime));
            }
            else
            {
                direction = currentPoint - bezier.CalculateCurvePoint(bezier.curve.Evaluate(bezier.curveTime - Time.deltaTime));
            }

            curvingObject.right = direction;
        }
    }
}