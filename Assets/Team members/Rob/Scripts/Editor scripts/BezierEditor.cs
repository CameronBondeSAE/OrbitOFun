using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rob
{


    [CustomEditor(typeof(BezierCurve))]
    public class BezierEditor : Editor

    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Play Curve"))
            {
                ((BezierCurve) target).PlayCurve();
            }
        }

    }
}
