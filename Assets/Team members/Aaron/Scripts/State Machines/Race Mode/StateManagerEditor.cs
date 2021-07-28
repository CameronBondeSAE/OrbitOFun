using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace  AaronMcDougall
{
    [CustomEditor(typeof(RaceModeStateManager), true)]
    public class StateManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Change State"))
            {
                ((RaceModeStateBase) target).Enter();
            }
        }
    }
}