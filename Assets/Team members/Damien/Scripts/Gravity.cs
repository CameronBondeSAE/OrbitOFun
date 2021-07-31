using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Damien
{
    public class Gravity : MonoBehaviour
    {
        // Inspector vars
        [Header("Object Variables")] public bool isPlanet; // is this object a planet or black hole or similar?
        public bool isAffectedByGravity; // is this object affected by gravity?
        public float localMass = 1f; // increases or decreases this entities mass, affecting its gravitational pull
        public float forceMultiplier = 1f;


        //Universal vars
        private Rigidbody rb;
        private GravityManager gravManager; // may not even end up using this
        private bool canBePulled;
        public double gravConst = 6.67 * Math.Pow(10, -11);
        private LayerMask gravAffectedLayer;


        //Planet vars
        private float pullRadius;
        private float pullStrength = 0f; // may not even end up using this
        public List<Rigidbody> pullableObjRB = new List<Rigidbody>();
        private Vector3 planetPos;


        void Start()
        {
            gravAffectedLayer = LayerMask.NameToLayer("GravAffected");
            gravManager = FindObjectOfType<GravityManager>();
            rb = GetComponent<Rigidbody>();
            rb.mass = localMass;
            rb.useGravity = false;

            switch (isPlanet)
            {
                // checks whether the object is a planet and executes the appropriate code
                case true:
                    pullRadius = localMass * 2f;
                    planetPos = transform.position;
                    StartCoroutine(CheckObjectsInRadius());
                    break;

                case false:
                    pullRadius = 0f;
                    forceMultiplier = 0f;
                    break;
            }

            switch (isAffectedByGravity)
            {
                // checks whether the object can move and sets the rigidbody accordingly
                case true:
                    rb.isKinematic = false;
                    rb.constraints = RigidbodyConstraints.None;
                    gameObject.layer = 10;
                    canBePulled = true;
                    break;

                case false:
                    rb.isKinematic = true;
                    canBePulled = false;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    break;
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
            //pullableObjRB.Clear();
            Collider[] pullableObjColl =
                Physics.OverlapSphere(planetPos, pullRadius, gravAffectedLayer); //doesnt work for some reason
            for (int i = 0; i < pullableObjColl.Length; i++)
            {
                Collider obj = pullableObjColl[i];
                pullableObjRB.Add(obj.attachedRigidbody);
            }

            PullObjectsInList();
        }

        public void PullObjectsInList()
        {
            foreach (var objRB in pullableObjRB)
            {
                float objMass = objRB.mass;
                float distance = Vector3.Distance(transform.position, objRB.transform.position);
                double pullForce = gravConst * ((objMass * localMass) / Math.Pow(distance, 2));
                objRB.AddForce((planetPos - objRB.position) * ((float) pullForce * forceMultiplier));
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, pullRadius);
        }


        void Update()
        {
        }
    }
}