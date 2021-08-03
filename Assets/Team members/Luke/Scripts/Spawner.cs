using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace LukeBaker
{
    public class Spawner : MonoBehaviour
    {
        //references
        private PlanetManager planetManager;

        //variables
        public int amount;
        [Tooltip("Mass will also effect the size")]
        public float maxMass;
        [Tooltip("Mass will also effect the size")]
        public float minMass;
        private float planetMass;
        private Rigidbody rb;
        private Transform currentSpawnPos;
        private Vector3 newPosition;
        public GameObject prefabToSpawn;
        private GameObject currentSpawn;
        public float minSpawnRange;
        public float maxSpawnRange;
        private float xSpawnPos;
        private float ySpawnPos;
        private float zSpawnPos;
        
        //events
        public event Action<GameObject> spawnedPlanetEvent;

        // Start is called before the first frame update
        void Start()
        {
            planetManager = FindObjectOfType<PlanetManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            for (int j = 0; j < amount; j++)
            {
                //setting up new random pos
                 xSpawnPos = Random.Range(minSpawnRange, maxSpawnRange);
                 ySpawnPos = Random.Range(minSpawnRange, maxSpawnRange);
                 zSpawnPos = Random.Range(minSpawnRange, maxSpawnRange);
                 Vector3 transformPosition = transform.position;
                 newPosition = new Vector3(transformPosition.x + xSpawnPos,transformPosition.y + ySpawnPos,transformPosition.z + zSpawnPos);
                 
                 //instantiate
                 currentSpawn = Instantiate(prefabToSpawn, newPosition, Quaternion.identity);
                 
                 //randomizing and setting the mass the current object
                 planetMass = Random.Range(minMass, maxMass);
                 rb = currentSpawn.GetComponent<Rigidbody>();
                 rb.mass = planetMass;
                 
                 //changing the size relative to the mass
                 currentSpawn.transform.localScale =
                     new Vector3(planetMass, planetMass, planetMass);
                 
                 //passing to the gravitational object script
                 spawnedPlanetEvent?.Invoke(currentSpawn.gameObject);
            }
        }
    }
}
