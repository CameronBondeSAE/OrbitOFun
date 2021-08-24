using System.Collections;
using System.Collections.Generic;
using Tim;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Change to Lobby State"))
            {
                //((GameManager)target).GetComponent<StateManager>()?.ChangeState();

                Debug.Log("Change to Lobby State");
            }

            if (GUILayout.Button("Change to InGame State"))
            {
                Debug.Log("Change to InGame State");

            }

            if (GUILayout.Button("Change to EndGame State"))
            {
                Debug.Log("Change to EndGame State");

            }
        }
    }
}