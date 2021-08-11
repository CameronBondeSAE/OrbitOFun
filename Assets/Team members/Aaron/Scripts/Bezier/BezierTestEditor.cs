using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{
    [CustomEditor(typeof(BezierTest))]
    public class BezierTestEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Play movement"))
            {
                ((BezierTest) target).PlayMovement();
            }
        }
    }
}

