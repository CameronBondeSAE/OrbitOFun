using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    // Not sure what script is specific to BattlePlayer?
    //[CustomEditor(typeof(???)]
    public class BattlePlayerStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Change to Control State"))
            {
                Debug.Log("Change to Control State");
            }

            if (GUILayout.Button("Change to Launch State"))
            {
                Debug.Log("Change to Launch State");

            }

            if (GUILayout.Button("Change to Destroyed State"))
            {
                Debug.Log("Change to Destroyed State");

            }
        }
    }
}