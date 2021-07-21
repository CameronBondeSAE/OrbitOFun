using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RileyMcGowan.GravityManager))]
public class GravityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("AddVelocity"))
        {
            (target as GravityManager)?.AddVelocity();
        }
    }
}
