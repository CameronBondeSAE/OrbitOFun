using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Tom
{
    public class BezierCurve : CommonObject, IGameModeInteractable
    {
        private Vector2 curvePoint;
        [Range(0f, 1f)] public float curveTime;
        public float duration = 1f;
        public bool autoplay = true;
        public Transform controlPoint1, controlPoint2, controlPoint3, controlPoint4;
        private bool playingCurve = false;
        public AnimationCurve curve;

        public event Action FinishedCurveEvent;
        public UnityEvent FinishedCurveUnityEvent;
        public event Action ReverseFinishedCurveEvent;
        public UnityEvent ReverseFinishedUnityEvent;

        public enum PlayType
        {
            SinglePlay,
            Loop,
            PingPong
        }

        public PlayType playType;

        public bool reversing = false;

        private void Update()
        {
            // HACK
            // Pretty messy but gets the job done
            // Checks for what play type is selected to determine whether it goes forward or reverse, what happens when finished etc
            if (playingCurve)
            {
                if (reversing && playType == PlayType.PingPong)
                {
                    curveTime -= Time.deltaTime / duration;
                }
                else
                {
                    curveTime += Time.deltaTime / duration;
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
        }

        public Vector2 CalculateCurvePoint(float time)
        {
            // Calculates the lerp for each control point, then lerps between those to get final curve point
            Vector2 a = Vector2.Lerp(controlPoint1.position, controlPoint2.position, curve.Evaluate(time));
            Vector2 b = Vector2.Lerp(controlPoint2.position, controlPoint3.position, curve.Evaluate(time));
            Vector2 c = Vector2.Lerp(controlPoint3.position, controlPoint4.position, curve.Evaluate(time));
            Vector2 d = Vector2.Lerp(a, b, curve.Evaluate(time));
            Vector2 e = Vector2.Lerp(b, c, curve.Evaluate(time));

            return Vector2.Lerp(d, e, curve.Evaluate(time));
        }

        public void PlayCurve()
        {
            curveTime = 0;
            playingCurve = true;
        }

        public void Activate()
        {
            if (autoplay)
            {
                PlayCurve();
            }
        }

        public void CallFinishedCurve()
        {
            FinishedCurveEvent?.Invoke();
            FinishedCurveUnityEvent.Invoke();
            print("finished curve");
        }

        public void CallReverseFinishedCurve()
        {
            ReverseFinishedCurveEvent?.Invoke();
            ReverseFinishedUnityEvent.Invoke();
            print("reverse finished curve");
        }

        public void OnDrawGizmos()
        {
            Handles.DrawBezier(controlPoint1.position, controlPoint4.position, controlPoint2.position,
                controlPoint3.position, Color.white, null, 2f);
        }
    }
}