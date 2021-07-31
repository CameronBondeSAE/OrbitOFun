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

        // Start is called before the first frame update
        void Start()
        {
            counter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            SpawnGravObjects();
        }

        void SpawnGravObjects()
        {
            if (spawnInUpdate)
            {
                Instantiate(gravObject, transform.position, Quaternion.identity);
                counter++;
            }
        }
    }
}