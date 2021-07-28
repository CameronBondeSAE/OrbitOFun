using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{
    [CustomEditor(typeof(RaceModeStateBase), true)]
    public class StateManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Change State"))
            {
                ((RaceModeStateBase)target).GetComponent<RaceModeStateManager>().ChangeState((RaceModeStateBase)target);
            }
        }
    }
}