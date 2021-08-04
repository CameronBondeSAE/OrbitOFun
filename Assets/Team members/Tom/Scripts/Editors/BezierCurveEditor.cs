using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(global::BezierCurve))]
    public class BezierCurveEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Play Curve"))
            {
                ((BezierCurve)target).PlayCurve();
            }
        }
    }
}