using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class BezierCurve : MonoBehaviour
    {
        private Vector2 curvePoint;

        [Range(0f, 1f)] public float curveTime;

        public Transform controlPoint1, controlPoint2, controlPoint3, controlPoint4;

        private bool playingCurve = false;

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
                        case PlayType.Loop:
                            curveTime = 0f;
                            break;
                        case PlayType.PingPong:
                            reversing = true;
                            break;
                        default:
                            break;
                    }
                }

                if (curveTime < 0f)
                {
                    reversing = false;
                }
            }
        }

        public void PlayCurve()
        {
            curveTime = 0;
            playingCurve = true;
        }

        public void OnDrawGizmos()
        {
            Vector2 a = Vector2.Lerp(controlPoint1.position, controlPoint2.position, curveTime);
            Vector2 b = Vector2.Lerp(controlPoint2.position, controlPoint3.position, curveTime);
            Vector2 c = Vector2.Lerp(controlPoint3.position, controlPoint4.position, curveTime);
            Vector2 d = Vector2.Lerp(a, b, curveTime);
            Vector2 e = Vector2.Lerp(b, c, curveTime);

            curvePoint = Vector2.Lerp(d, e, curveTime);
            Gizmos.DrawSphere(curvePoint, 0.1f);
        }
    }
}