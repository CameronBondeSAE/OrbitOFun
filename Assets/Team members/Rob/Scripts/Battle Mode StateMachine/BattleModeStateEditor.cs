using System.Collections;
using System.Collections.Generic;
using Rob;
using UnityEditor;
using UnityEngine;

namespace Rob
{
    [CustomEditor(typeof(BattleModeStateBase), true)]
    
    public class BattleModeStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Force Enter"))
            {
                ((BattleModeStateBase) target).Enter();
            }

            if (GUILayout.Button("Force Execute"))
            {
                ((BattleModeStateBase) target).Execute();
            }
            
            if (GUILayout.Button("Force Exit"))
            {
                ((BattleModeStateBase) target).Exit();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}
