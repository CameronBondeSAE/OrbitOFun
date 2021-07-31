using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using Damien;
using UnityEngine;

namespace Damien
{
    public class GravityManager : MonoBehaviour
    {
        public List<Rigidbody> planetEntities;

        public List<Rigidbody> nonPlanetEntities;

        void Start()
        {
            //Grabs all objects in the scene that have the gravity script
            Gravity[] allEntitiesWithGravity = FindObjectsOfType<Gravity>();

            foreach (var entity in allEntitiesWithGravity)
            {
                
                if (entity.isPlanet)
                {
                    planetEntities.Add(entity.GetComponent<Rigidbody>());
                }

                if (!entity.isPlanet)
                {
                    nonPlanetEntities.Add(entity.GetComponent<Rigidbody>());
                }
                
            }
        }
        
        

        // Update is called once per frame
        void Update()
        {
        }
    }
}