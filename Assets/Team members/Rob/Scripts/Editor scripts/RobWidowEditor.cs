using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class RobWindowEditor : EditorWindow
{
    
    bool groupEnabled;
    private bool randomSize = true;
    public GameObject objectToSpawn;
    public int numberOfObjectsToSpawn;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public Vector2 scale;
    public bool delete = false;
    public List<GameObject> ObjDelete;









    // Add menu named "Robs Editor" to the Window menu
    [MenuItem("Tools/Robs Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RobWindowEditor window = (RobWindowEditor)EditorWindow.GetWindow(typeof(RobWindowEditor));
        window.Show();
    }
    

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        objectToSpawn = (GameObject)EditorGUILayout.ObjectField("Object to spawn",objectToSpawn, typeof(GameObject), true);
        numberOfObjectsToSpawn = EditorGUILayout.IntField("Number to spawn", numberOfObjectsToSpawn);
        minX = EditorGUILayout.FloatField("Position min X", minX);
        maxX = EditorGUILayout.FloatField("Position max X", maxX);
        minY = EditorGUILayout.FloatField("Position min Y", minY);
        maxY = EditorGUILayout.FloatField("Position max Y", maxY);

        //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        
        randomSize = EditorGUILayout.Toggle("RandomSize", randomSize);
        scale = EditorGUILayout.Vector2Field("Scale", scale);
        
        

       
        
            if (GUILayout.Button("SPAWN"))
            {
                for (int i = 0; i < numberOfObjectsToSpawn; i++)
                {
                    //GameObject newSquare = Instantiate(objectToSpawn, new Vector3(Random.Range(minX, maxX) * 1f, Random.Range(minY, maxY), 0), Quaternion.identity);
                    GameObject newSquare = PrefabUtility.InstantiatePrefab(objectToSpawn) as GameObject;
                    newSquare.transform.position = new Vector3(Random.Range(minX, maxX) * 1f, Random.Range(minY, maxY), 0);
                    if (randomSize)
                    {
                        float randomScale = Random.Range(scale.x,scale.y);
                        
                        if (randomSize)
                        {
                            newSquare.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                        }
                        ObjDelete.Add(newSquare);
                    }
                    

                }

                

            }
        
        if (GUILayout.Button("DELYEET"))
        {
            if (ObjDelete.Count > 0)
            {
                foreach (GameObject obj in ObjDelete)
                {
                    DestroyImmediate(obj);
                }
            }
        }

        if (GUILayout.Button("SAVE"))
        {
            OnDisable();
        }
        
        if (GUILayout.Button("LOAD"))
        {
            OnEnable();
        }

        


        //EditorGUILayout.EndToggleGroup();
    }
    

    public void OnDisable()
    {
        
        string save = JsonUtility.ToJson(this, true);
        Debug.Log(save);
        
        PlayerPrefs.SetString("Settings", save);
        
    }

    public void OnEnable()
    {
        string load =  PlayerPrefs.GetString("Settings");
        JsonUtility.FromJsonOverwrite(load, this);
        Debug.Log("load " + load);
        
    }
    
}
