using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Damien
{
    public class GravObjectSpawner : MonoBehaviour
    {
        public GameObject gravObject;
        public bool spawnInUpdate;
        public int counter;
        public bool ambientSpawn;
        public int timer;


        // Start is called before the first frame update
        void Start()
        {
            ambientSpawn = true;
            counter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (spawnInUpdate)
            {
                SpawnGravObject();
                if (ambientSpawn)
                {
                    ambientSpawn = false;
                }
            }

            if (ambientSpawn)
            {
               AmbientSpawn();
               if (spawnInUpdate)
               {
                   spawnInUpdate = false;
               }
            }
        }

        void SpawnGravObject()
        {
            Instantiate(gravObject, transform.position, Quaternion.identity);
            counter++;
        }

        void AmbientSpawn()
        {
            timer++;
            if (timer >= 30)
            {
                SpawnGravObject();
                timer = 0;
            }
        }
    }
}