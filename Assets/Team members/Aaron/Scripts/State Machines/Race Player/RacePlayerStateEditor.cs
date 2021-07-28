using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{
    [CustomEditor(typeof(RacePlayerStateBase), true)]
    public class RacePlayerStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Change State"))
            {
                ((RacePlayerStateBase)target).GetComponent<RacePlayerStateManager>().ChangeState((RacePlayerStateBase)target);
            }
        }
    }
}