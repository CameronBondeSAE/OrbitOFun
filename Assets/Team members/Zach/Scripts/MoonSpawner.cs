using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class MoonSpawner : MonoBehaviour
    {
        //Game objects here are for the prefab of the object to spawn
        public GameObject moonPrefab;
        
        //The temporarily selected moon that is created through instantiate 
        public GameObject currentMoon;
        public int amountOfMoons;
        
        //Floats used to create a random position within space
        public float xOffset;
        public float yOffset;
        public float zOffset;

        public float xVelocity;
        public float yVelocity;
        public float zVelocity;
        
        //The actual position for the randomised moon spawn
        public Vector3 position;
        
        void Start()
        {
            for (int i = 0; i < amountOfMoons; i++)
            {
                //Randomising the floats 
                xOffset = Random.Range(-4f, 4f);
                yOffset = Random.Range(-4f, 4f);
                zOffset = Random.Range(-4f, 4f);
                //Randomising the velocity
                xVelocity = Random.Range(-2f, 2f);
                yVelocity = Random.Range(-2f, 2f);
                zVelocity = Random.Range(-2f, 2f);

                Vector3 transformPosition = transform.position;
                //Setting the position of the moon that is to be spawned
                position = new Vector3(transformPosition.x + xOffset,transformPosition.y + yOffset,transformPosition.z + zOffset  );
                currentMoon = Instantiate(moonPrefab,position,new Quaternion(0,0,0,0));
                //Setting a random velocity based on the offsets 
                currentMoon.GetComponent<Rigidbody>().velocity = new Vector3(xVelocity, yVelocity, zVelocity);
            }
        }
    }
}
