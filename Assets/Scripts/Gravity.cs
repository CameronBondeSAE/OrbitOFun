using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class Gravity : CommonObject, IGameModeInteractable
    {
        //Private Vars
        private bool isActivated = false;
        
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

        public void Activate()
        {
            isActivated = true;
        }
    }
}