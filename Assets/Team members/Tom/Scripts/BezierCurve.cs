using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class BezierCurve : MonoBehaviour
    {
        public Transform curvingObject;

        private Vector2 curvePoint;

        [Range(0f, 1f)] public float curveTime;

        public Transform controlPoint1, controlPoint2, controlPoint3, controlPoint4;

        private bool playingCurve = false;

        public AnimationCurve curve;

        public event Action FinishedCurveEvent;
        public event Action ReverseFinishedCurveEvent;

        public enum PlayType
        {
            SinglePlay,
            Loop,
            PingPong
        }

        public PlayType playType;

        private bool reversing = false;

        private void Update()
        {
            // HACK
            // Pretty messy but gets the job done
            // Checks for what play type is selected to determine whether it goes forward or reverse, what happens when finished etc
            if (playingCurve)
            {
                if (reversing && playType == PlayType.PingPong)
                {
                    curveTime -= Time.deltaTime;
                }
                else
                {
                    curveTime += Time.deltaTime;
                }

                if (curveTime > 1f)
                {
                    switch (playType)
                    {
                        case PlayType.SinglePlay:
                            curveTime = 1f;
                            playingCurve = false;
                            break;
                        case PlayType.Loop:
                            curveTime = 0f;
                            break;
                        case PlayType.PingPong:
                            curveTime = 1f;
                            reversing = true;
                            break;
                        default:
                            break;
                    }
                    
                    CallFinishedCurve();
                }

                if (curveTime < 0f)
                {
                    CallReverseFinishedCurve();
                    reversing = false;
                }
            }
            
            // Calculates the lerp for each control point, then lerps between those to get final curve point
            Vector2 a = Vector2.Lerp(controlPoint1.position, controlPoint2.position, curve.Evaluate(curveTime));
            Vector2 b = Vector2.Lerp(controlPoint2.position, controlPoint3.position, curve.Evaluate(curveTime));
            Vector2 c = Vector2.Lerp(controlPoint3.position, controlPoint4.position, curve.Evaluate(curveTime));
            Vector2 d = Vector2.Lerp(a, b, curve.Evaluate(curveTime));
            Vector2 e = Vector2.Lerp(b, c, curve.Evaluate(curveTime));

            curvePoint = Vector2.Lerp(d, e, curve.Evaluate(curveTime));
            curvingObject.position = curvePoint;
            
            // Sets forward point in 2D to direction curve is going
            Vector2 direction;
            if (reversing)
            {
                direction = curvePoint - Vector2.Lerp(d, e, curve.Evaluate(curveTime + Time.deltaTime));
            }
            else
            {
                direction = curvePoint - Vector2.Lerp(d, e, curve.Evaluate(curveTime - Time.deltaTime));
            }
            curvingObject.right = direction;
        }

        public void PlayCurve()
        {
            curveTime = 0;
            playingCurve = true;
        }

        public void CallFinishedCurve()
        {
            FinishedCurveEvent?.Invoke();
            print("finished curve");
        }

        public void CallReverseFinishedCurve()
        {
            ReverseFinishedCurveEvent?.Invoke();
            print("reverse finished curve");
        }

        public void OnDrawGizmos()
        {
            Gizmos.DrawSphere(curvePoint, 0.1f);
        }
    }
}