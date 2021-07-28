using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class CanGravitate : MonoBehaviour
    {
        //Private Vars

        //Public Vars
        public Rigidbody rb; //Store the rigidbody to prevent constantly using get component
        public static event Action<CanGravitate> OnCanGravitate = delegate {  };
        public static event Action<CanGravitate> OnStopGravitate = delegate {  };
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            OnCanGravitate(this);
        }

        public void OnDestroy()
        {
            OnStopGravitate(this);
        }
    }
}