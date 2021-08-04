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
    public GameObject spawnSquare;
    public GameObject spawnCircle;
    public int numberToSpawnSquare;
    public int numberToSpawnCircle;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public Vector2 xScale;
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
        spawnCircle = (GameObject)EditorGUILayout.ObjectField("Spawn Circle", spawnCircle, typeof(GameObject), true);
        spawnSquare = (GameObject)EditorGUILayout.ObjectField("spawn Square",spawnSquare, typeof(GameObject), true);
        numberToSpawnSquare = EditorGUILayout.IntField("number to spawn Square", numberToSpawnSquare);
        numberToSpawnCircle = EditorGUILayout.IntField("number to spawn Circle", numberToSpawnCircle);
        minX = EditorGUILayout.FloatField("Position min X", minX);
        maxX = EditorGUILayout.FloatField("Position max X", maxX);
        minY = EditorGUILayout.FloatField("Position min Y", minY);
        maxY = EditorGUILayout.FloatField("Position max Y", maxY);

        //groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        
        randomSize = EditorGUILayout.Toggle("RandomSize", randomSize);
        xScale = EditorGUILayout.Vector2Field("X Scale", xScale);
        
        

        if (groupEnabled)
        {
            if (GUILayout.Button("SPAWN"))
            {
                for (int i = 0; i < numberToSpawnSquare; i++)
                {
                    GameObject newSquare = Instantiate(spawnSquare, new Vector3(Random.Range(minX, maxX) * 1f, Random.Range(minY, maxY), 0), Quaternion.identity);
                    if (randomSize)
                    {
                        float randomScale = Random.Range(xScale.x,xScale.y);
                        
                        if (randomSize)
                        {
                            newSquare.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                        }
                        ObjDelete.Add(newSquare);
                    }
                    

                }
                for (int x = 0; x < numberToSpawnCircle; x++)
                {
                    GameObject newCircle = Instantiate(spawnCircle, new Vector3(Random.Range(minX, maxX) * 2f, Random.Range(minY, maxY),0), Quaternion.identity);
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
