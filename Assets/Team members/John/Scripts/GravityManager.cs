using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace John
{
    public class GravityManager : MonoBehaviour
    {
        public List<GameObject> GravityApplied;
        public List<GameObject> GravityCentres;
        public GameObject planetPrefab;
        public GameObject pullPrefab;
        public Vector3 randomLocation;

        public int PlanetsToSpawn;
        public int PullsToSpawn;
        private void Awake()
        {
            
            
            while(PlanetsToSpawn > 0)
            {
                Instantiate(planetPrefab, randomLocation, quaternion.identity);
                PlanetsToSpawn--;
            }
            
            while(PullsToSpawn > 0)
            {
                Instantiate(pullPrefab, randomLocation, quaternion.identity);
                PullsToSpawn--;
            }
            
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.CompareTag("Player"))
                {
                    GravityApplied.Add(go);
                }
            }

            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.GetComponent<Centre>())
                {
                    GravityCentres.Add(go);
                }
            }

            
        }

        private void Update()
        {
            randomLocation = new Vector3((Random.Range(0f, 25f)), (Random.Range(0f, 25f)), (Random.Range(0.0f, 25.0f)));
        }
    } 
}

