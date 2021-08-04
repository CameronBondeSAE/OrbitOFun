using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Damien
{
    public class Gravity : MonoBehaviour
    {
        // Inspector vars
        [Header("Object Variables")] public bool isPlanet; // is this object a planet or black hole or similar?
        public bool isAffectedByGravity; // is this object affected by gravity?
        public float localMass = 1f; // increases or decreases this entities mass, affecting its gravitational pull
        public float forceMultiplier = 1000000f;


        //Universal vars
        private Rigidbody rb;
        private double gravConst = 6.67 * Math.Pow(10, -11);
        private float scaleAvg;

        [Header("Planet Variables")] private float pullRadius;
        private List<Rigidbody> pullableObjRB = new List<Rigidbody>();
        private Vector3 planetPos;
        public float radiusBoost = 10f;

        //Non Planet vars
        [Header("Non Planet Variables")] public Vector3 initialForce;
        public bool randomizeInitalForce;

        void Start()
        {
            //gravAffectedLayer = LayerMask.NameToLayer("GravAffected");
            //gravManager = FindObjectOfType<GravityManager>();
            rb = GetComponent<Rigidbody>();
            rb.mass = localMass;
            rb.useGravity = false;
            scaleAvg = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;

            switch (isAffectedByGravity)
            {
                // checks whether the object can move and sets the rigidbody accordingly
                case true:
                    
                    rb.isKinematic = false;
                    rb.constraints = RigidbodyConstraints.None;
                    break;

                case false:
                    rb.isKinematic = true;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    break;
            }

            switch (isPlanet)
            {
                // checks whether the object is a planet and executes the appropriate code
                case true:
                    pullRadius = scaleAvg + radiusBoost;
                    planetPos = transform.position;
                    initialForce = Vector3.zero;
                    StartCoroutine(CheckObjectsInRadius());
                    break;

                case false:
                    if (randomizeInitalForce)
                    {
                        RandomGen();
                    }

                    pullRadius = 0f;
                    forceMultiplier = 0f;
                    rb.AddRelativeForce(initialForce);
                    break;
            }
        }

        void RandomGen()
        {
            if (initialForce.x == 0)
            {
                initialForce.x = Random.Range(-30, 30);
            }

            if (initialForce.y == 0)
            {
                initialForce.y = Random.Range(-30, 30);
            }

            if (initialForce.z == 0)
            {
                initialForce.z = Random.Range(0, 50);
            }
        }


        IEnumerator CheckObjectsInRadius()
        {
            while (true)
            {
                CheckObjectsInRange();
                yield return new WaitForSeconds(0.1f);
            }
        }

        public void CheckObjectsInRange()
        {
            Collider[] pullableObjColl = Physics.OverlapSphere(planetPos, pullRadius);
            // doesnt work for some reason

            for (int i = 0; i < pullableObjColl.Length; i++)
            {
                GameObject obj = pullableObjColl[i].gameObject;
                Gravity objGr = obj.GetComponent<Gravity>();
                if (objGr != null)
                {
                    if (objGr.isAffectedByGravity)
                    {
                        pullableObjRB.Add(obj.GetComponent<Rigidbody>());
                    }
                }
            }

            PullObjectsInList();
        }

        public void PullObjectsInList()
        {
            foreach (Rigidbody objRB in pullableObjRB.ToList())
            {
                float objMass = objRB.mass;
                float distance = Vector3.Distance(transform.position, objRB.transform.position);
                //float distance = (transform.position - objRB.transform.position).magnitude;
                double pullForce = gravConst * ((objMass * localMass) / Math.Pow(distance, 2));
                objRB.AddForce((planetPos - objRB.position) * ((float) pullForce * forceMultiplier));
                pullableObjRB.Remove(objRB);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, pullRadius);
        }

        private void OnCollisionEnter(Collision other)
        {
            
            Gravity gravity = other.gameObject.GetComponent<Gravity>();
            if (gravity != null)
            {
                if (isPlanet)
                {
                    if (gravity.isPlanet == false)
                    {
                        Destroy(other.gameObject);
                    }
                }
            }
        }


        void Update()
        {
        }
    }
}