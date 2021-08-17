using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zach;

namespace Tom
{
    [CustomEditor(typeof(GameModeBase))]
    public class GameModeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Activate Game Mode"))
            {
                ((GameModeBase)target).Activate();
            }

            if (GUILayout.Button("End Game Mode"))
            {
                //((GameModeBase) target).EndMode();
            }
        }
    }
}