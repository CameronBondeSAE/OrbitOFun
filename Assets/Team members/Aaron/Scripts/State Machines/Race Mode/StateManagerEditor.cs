using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{
    [CustomEditor(typeof(StateBase), true)]
    public class StateManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector ();
            
            if (GUILayout.Button("Change State"))
            {
                ((StateBase)target).GetComponent<RaceModeStateManager>().ChangeState((StateBase)target);
            }
        }
    }
}