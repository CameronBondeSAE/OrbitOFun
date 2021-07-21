using System;
using UnityEngine;
using Damien;

namespace Damien
{
    public class Gravity : MonoBehaviour
    {
        public bool isStaticEntity; //is this object a planet or black hole or similar?
        public Rigidbody rb;
        public GravityManager gravManager;
        public float mass;

        // Start is called before the first frame update
        void Start()
        {
            gravManager = FindObjectOfType<GravityManager>();
            rb = GetComponent<Rigidbody>();
            mass = rb.mass;
            rb.useGravity = false;
            if (isStaticEntity)
            {
                rb.isKinematic = true;
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}