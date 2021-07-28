using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Gravity : MonoBehaviour
    {
        //Private Vars
        
        //Public Vars
        public Rigidbody rb;
        public static event Action<Gravity> OnGravityMass = delegate {  };
        public static event Action<Gravity> OnStopGravityMass = delegate {  };
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            OnGravityMass(this);
        }

        public void OnDestroy()
        {
            OnStopGravityMass(this);
        }
    }
}