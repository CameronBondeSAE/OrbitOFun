using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LukeBaker
{
    public class PlanetManager : MonoBehaviour
    {
        //references
        private Spawner spawner;
        
        //variables
        public List<GravitationalObject> gravitationalObjects;
        public float maxPosVelocity;
        public float minNegVelocity;
        private float xVelocity;
        private float yVelocity;
        private float zVelocity;
        private Rigidbody currentRb;
        
        
        //The gravitational constance
        public float g;

        private void OnEnable()
        {
            spawner = FindObjectOfType<Spawner>();
            spawner.spawnedPlanetEvent += AddToList;
        }

        private void OnDisable()
        {
            spawner.spawnedPlanetEvent -= AddToList;
        }

        // Start is called before the first frame update
        void Start()
        {
            gravitationalObjects.AddRange(FindObjectsOfType<GravitationalObject>());
            ApplyRandomVelocity();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ApplyRandomVelocity()
        {
            foreach (GravitationalObject obj in gravitationalObjects)
            {
                xVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
                yVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
                zVelocity = Random.Range(-minNegVelocity, maxPosVelocity);
                obj.GetComponent<Rigidbody>().velocity = new Vector3(xVelocity, yVelocity, zVelocity);
            }
        }

        public void AddToList(GameObject newPlanet)
        {
            gravitationalObjects.Add(newPlanet.GetComponent<GravitationalObject>());
        }
    }
}
