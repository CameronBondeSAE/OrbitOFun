using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rob
{
    [CustomEditor(typeof(MenuUIStateBase), true)]


    public class MenuUIStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Force Enter"))
            {
                ((MenuUIStateBase) target).Enter();
            }

            if (GUILayout.Button("Force Execute"))
            {
                ((MenuUIStateBase) target).Execute();
            }
            
            if (GUILayout.Button("Force Exit"))
            {
                ((MenuUIStateBase) target).Exit();
            }
            
            GUILayout.EndHorizontal();
        }
    }
}
