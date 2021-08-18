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
        [Tooltip("Use size to change radius?")]
        public bool useObjectSize = true;
        [Tooltip("This will be set automatically")]
        public Rigidbody rb;
        public Renderer renderer;
        public static event Action<Gravity> OnGravityMass = delegate {  };
        public static event Action<Gravity> OnStopGravityMass = delegate {  };
        
        private void Start()
        {
            if (GetComponent<Renderer>() != null)
            {
                renderer = GetComponent<Renderer>();
            }
            if (GetComponent<Rigidbody>() != null)
            {
                rb = GetComponent<Rigidbody>();
            }
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