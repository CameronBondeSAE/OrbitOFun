using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Luke
{
    public class GravitationalObject : MonoBehaviour
    {
        //Variables
        private Rigidbody rb;
        public List<GravitationalObject> gravitationalObjects;
        private float maxDistance;
        private float distance;
        private Vector3 direction;
        private float forceMagnitude;
        private Vector3 force;
        private Rigidbody attractedRb;

        //The gravitational constance
        private float g = 100f;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            gravitationalObjects.AddRange(FindObjectsOfType<GravitationalObject>());
        }

        // Update is called once per frame
        void Update()
        {
            GravityToAllObj();
        }

        public void Attract(GravitationalObject objectToAttract)
        {
            attractedRb = objectToAttract.rb;

            direction = transform.position - attractedRb.position;
            distance = direction.magnitude;

            //newtons universal law of gravity
            forceMagnitude = g * (rb.mass * attractedRb.mass) / Mathf.Pow(distance, 2);

            force = direction.normalized * forceMagnitude;
            attractedRb.AddForce(force);
        }

        public void GravityToAllObj()
        {
            foreach (GravitationalObject obj in gravitationalObjects)
            {
                //so it doesn't attract itself
                if (obj != this)
                {
                    Attract(obj);
                }
            }
        }
    }
}
