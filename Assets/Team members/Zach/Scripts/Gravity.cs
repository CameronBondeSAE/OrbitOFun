using System.Collections.Generic;
using UnityEngine;

namespace Zach
{
    public class Gravity : CommonObject, IGameModeInteractable
    {
        //New version of my gravity script
        //Static list of game objects, newed here so that Unity realises it exists 
        public static List<GameObject> orbitalsStatic = new List<GameObject>();

        //original version of my gravity script
        public Rigidbody rigidbody;

        public Vector3 direction;
        public Vector3 gravityForce;
        public float distance;
        public bool isActivated;

        public void Awake()
        {
            orbitalsStatic.Add(gameObject);
        }


        public void Update()
        {
            if (isActivated)
            {
                foreach (var orbital in orbitalsStatic)
                {
                    if (orbital != gameObject)
                    {
                        var otherPosition = orbital.transform.position;
                        var transformPosition = transform.position;
                        direction = (otherPosition - transformPosition).normalized;
                        distance = Vector3.Distance(otherPosition, transformPosition);
                        gravityForce = -direction / distance * rigidbody.mass;
                        orbital.GetComponent<Rigidbody>().AddForce(gravityForce);
                    }
                }
            }
        }

        //Implementation of the I game mode interactable interface
        public void Activate()
        {
            isActivated = true;
        }
    }
}