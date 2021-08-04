using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{

    [CustomEditor(typeof(BezierTest),true)]
    public class BezierTestEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            
            if (GUILayout.Button("Play movement"))
            {
                ((BezierTest) target).t = 0f;
                ((BezierTest) target).speed = 0.5f;
            }

            //set to loop
            if (GUILayout.Button("Loop movement"))
            {
                if (((BezierTest) target).GetComponent<BezierTest>().loopMovement != true)
                    {
                        ((BezierTest) target).GetComponent<BezierTest>().loopMovement = true;
                    }
                    else
                    {
                        ((BezierTest) target).GetComponent<BezierTest>().loopMovement = false;
                    }
                
                    Debug.Log(((BezierTest) target).GetComponent<BezierTest>().loopMovement);
            }
        }
    }
}

