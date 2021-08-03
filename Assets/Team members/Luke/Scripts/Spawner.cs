using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LukeBaker
{
    public class Spawner : MonoBehaviour
    {
        [Tooltip("will spawn one of each in the list")]
        public List<GameObject> prefabsToSpawn;
        public int amount;
        public int currentPrefabElement;
        [Tooltip("Mass will also effect the size")]
        public float maxMass;
        [Tooltip("Mass will also effect the size")]
        public float minMass;
        private float planetMass;
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            for (int i = 0; i < prefabsToSpawn.Count; i++)
            {
                i = currentPrefabElement;
                
                for (int j = 0; j < amount; j++)
                {
                    //randomizing and setting the mass the current object
                    planetMass = Random.Range(minMass, maxMass);
                    rb = prefabsToSpawn[currentPrefabElement].GetComponent<Rigidbody>();
                    rb.mass = planetMass;
                    
                    //changing the size relative to the mass
                    prefabsToSpawn[currentPrefabElement].transform.localScale =
                        new Vector3(planetMass, planetMass, planetMass);
                    
                    Instantiate(prefabsToSpawn[currentPrefabElement]);
                }
            }
        }
    }
}
