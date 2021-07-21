using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Spawner : MonoBehaviour
    {
        //Private Vars
        private float spawnVelocity = 1.5f;
        
        //Public Vars
        public GameObject[] spawnablePrefabs;
        public int prefabsToSpawn;
        public float spawnLocationDistance;
        
        void Start()
        {
            for (int i = 0; i < prefabsToSpawn; i++)
            {
                GameObject objectToSpawn = spawnablePrefabs[Random.Range(0, spawnablePrefabs.Length)];
                Vector3 locationToSpawn = new Vector3(Random.Range(-spawnLocationDistance, spawnLocationDistance), Random.Range(-spawnLocationDistance, spawnLocationDistance), Random.Range(-spawnLocationDistance, spawnLocationDistance));
                Vector3 velocityToSpawn = new Vector3(Random.Range(-spawnVelocity, spawnVelocity), Random.Range(-spawnVelocity, spawnVelocity), Random.Range(-spawnVelocity, spawnVelocity));
                GameObject spawnedObject = Instantiate(objectToSpawn, locationToSpawn, Quaternion.identity);
                if (spawnedObject.GetComponent<Rigidbody>() != null)
                {
                    spawnedObject.GetComponent<Rigidbody>().velocity = velocityToSpawn;
                }
            }
        }
    }
}