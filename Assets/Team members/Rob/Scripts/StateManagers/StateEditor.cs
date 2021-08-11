using System.Collections;
using System.Collections.Generic;
using Rob;
using UnityEditor;
using UnityEngine;

namespace Rob
{
    [CustomEditor(typeof(StateBase), true)]
    
    public class StateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Force Enter"))
            {
                ((StateBase) target).Enter();
            }

            if (GUILayout.Button("Force Execute"))
            {
                ((StateBase) target).Execute();
            }
            
            if (GUILayout.Button("Force Exit"))
            {
                ((StateBase) target).Exit();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}
