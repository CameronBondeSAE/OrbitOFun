using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AaronMcDougall
{
    public class AaronSpawnEditorWindow : EditorWindow
    {
        //allows to drag in object/prefab
        public GameObject source;
        public GameObject copy;

        //the amount of objects they want to spawn per click
        public int objectAmount;

        //Location x coordinates
        public float xMin = 0;
        public float xMinLimit = 0;
        public float xMax = 100;
        public float xMaxLimit = 100;

        //Location y coordinates
        public float yMin = 0;
        public float yMinLimit = 0;
        public float yMax = 100;
        public float yMaxLimit = 100;

        //Rotation x values
        public float xRotMin = 0;
        public float xRotMinLimit = 0;
        public float xRotMax = 359;
        public float xRotMaxLimit = 359;

        //Rotation y values
        public float yRotMin = 0;
        public float yRotMinLimit = 0;
        public float yRotMax = 359;
        public float yRotMaxLimit = 359;

        //List for last spawned group of objects
        public List<GameObject> lastSpawned = new List<GameObject>();
        public List<GameObject> allSpawned = new List<GameObject>();

        //Vertical scroll variable
        public Vector2 scrollPos;

        //window access in menu
        [MenuItem("Tools/Aaron Spawn Window")]
        static void Init()
        {
            AaronSpawnEditorWindow window = (AaronSpawnEditorWindow) EditorWindow.GetWindow(typeof(AaronSpawnEditorWindow));
            window.Show();
        }

        //creates the window
        void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            GUILayout.Label("Object Spawning", EditorStyles.boldLabel);

            //Object input fields
            source = (GameObject) EditorGUILayout.ObjectField("Object to Spawn", source, typeof(GameObject), false);
            objectAmount = EditorGUILayout.IntField("Amount to Spawn", objectAmount);

            //Location Settings
            GUILayout.Label("Spawn Location Ranges", EditorStyles.boldLabel);
            //Display current, set new X values for spawn location
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Minimum X Value: ", xMin.ToString());
            EditorGUILayout.LabelField("Maximum X Value: ", xMax.ToString());
            GUILayout.EndHorizontal();
            EditorGUILayout.MinMaxSlider(ref xMin, ref xMax, xMinLimit, xMaxLimit);
            //Diplay current, set new Y values for spawn location
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Minimum Y Value: ", yMin.ToString());
            EditorGUILayout.LabelField("Minimum Y Value: ", yMax.ToString());
            GUILayout.EndHorizontal();
            EditorGUILayout.MinMaxSlider(ref yMin, ref yMax, yMinLimit, yMaxLimit);


            //Rotation Settings
            GUILayout.Label("Spawn Rotation Ranges", EditorStyles.boldLabel);
            //Display current, set new x values for spawn rotation
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Minimum X Value: ", xRotMin.ToString());
            EditorGUILayout.LabelField("Maximum X Value: ", xRotMax.ToString());
            GUILayout.EndHorizontal();
            EditorGUILayout.MinMaxSlider(ref xRotMin, ref xRotMax, xRotMinLimit, xRotMaxLimit);
            //Display current, set new y values for spawn rotation
            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Minimum Y Value: ", yRotMin.ToString());
            EditorGUILayout.LabelField("Maximum Y Value: ", yRotMax.ToString());
            GUILayout.EndHorizontal();
            EditorGUILayout.MinMaxSlider(ref yRotMin, ref yRotMax, yRotMinLimit, yRotMaxLimit);


            //Button which will spawn objects based on various previous inputs
            if (GUILayout.Button("Spawn Objects"))
            {
                lastSpawned.Clear();
                if (objectAmount > 0)
                {
                    for (int i = 0; i < objectAmount; i++)
                    {
                        GameObject copy = Instantiate(source,
                            new Vector3((Random.Range(xMin, xMax)), (Random.Range(yMin, yMax)), 0),
                            Quaternion.Euler((Random.Range(xRotMin, xRotMax)), (Random.Range(yRotMin, yRotMax)), 0));

                        lastSpawned.Add(copy);
                        allSpawned.Add(copy);
                    }
                }
            }

            //Button to clear all values 
            if (GUILayout.Button("Reset all values"))
            {
                xMin = 0;
                xMinLimit = 0;
                xMax = 100;
                xMaxLimit = 100;

                yMin = 0;
                yMinLimit = 0;
                yMax = 100;
                yMaxLimit = 100;

                xRotMin = 0;
                xRotMinLimit = 0;
                xRotMax = 359;
                xRotMaxLimit = 359;

                yRotMin = 0;
                yRotMinLimit = 0;
                yRotMax = 359;
                yRotMaxLimit = 359;
            }

            //Button to delete last group of spawned objects
            if (GUILayout.Button("Delete Last"))
            {
                foreach (GameObject thing in lastSpawned)
                {
                    GameObject.DestroyImmediate(thing, true);
                }

                lastSpawned.Clear();
            }

            //Button to delete all spawned objects
            if (GUILayout.Button("Delete All Objects"))
            {
                foreach (GameObject thing in allSpawned)
                {
                    GameObject.DestroyImmediate(thing, true);
                }

                allSpawned.Clear();
            }

            EditorGUILayout.EndScrollView();
        }

        public void OnEnable()
        {
            string load = PlayerPrefs.GetString("Spawn");
            JsonUtility.FromJsonOverwrite(load, this);
        }

        public void OnDisable()
        {
            string save = JsonUtility.ToJson(this, true);
            PlayerPrefs.SetString("Spawn", save);
        }
    }
}