using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LukeBaker
{
    public class GravitationalObject : CommonObject , IGameModeInteractable
    {
        //references
        private PlanetManager planetMan;
        
        //Variables
        private Rigidbody rb;
        private Rigidbody attractedRb;
        private float maxDistance;
        private float distance;
        private Vector3 direction;
        private float forceMagnitude;
        private Vector3 force;
        private GameObject instance;
        private bool isActivated;

        // Start is called before the first frame update
        void Start()
        {
            planetMan = FindObjectOfType<PlanetManager>();
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            GravityToAllObj();
        }

        public void Attract(GravitationalObject objectToAttract)
        {
            if (isActivated)
            {
                attractedRb = objectToAttract.rb;

                if (attractedRb != null)
                {
                    direction = transform.position - attractedRb.position;
                    distance = direction.magnitude;

                    //newtons universal law of gravity
                    forceMagnitude = planetMan.g * (rb.mass * attractedRb.mass) / Mathf.Pow(distance, 2);

                    force = direction.normalized * forceMagnitude;

                    attractedRb.AddForce(force);
                }
            }
        }

        public void GravityToAllObj()
        {
            foreach (GravitationalObject obj in planetMan.gravitationalObjects)
            {
                //so it doesn't attract itself
                if (obj != this)
                {
                    Attract(obj);
                }
            }
        }

        public void Activate()
        {
            isActivated = true;
        }
    }
}
