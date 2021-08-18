using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zach;

namespace Tom
{
    [CustomEditor(typeof(GameModeBase), true)]
    public class GameModeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawDefaultInspector();
            
            if (GUILayout.Button("Activate Game Mode"))
            {
                ((GameModeBase)target).Activate();
            }

            if (GUILayout.Button("End Game Mode"))
            {
                ((GameModeBase) target).EndGame();
            }
        }
    }
}