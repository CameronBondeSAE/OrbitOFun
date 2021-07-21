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
        public static event Action<CanGravitate> OnCanGravitate = delegate {  };
        public static event Action<CanGravitate> OnStopGravitate = delegate {  };
        public Rigidbody objectsRigidbody; //Store the rigidbody to prevent constantly using get component

        private void Start()
        {
            objectsRigidbody = GetComponent<Rigidbody>();
            OnCanGravitate(this);
        }

        public void OnDestroy()
        {
            OnStopGravitate(this);
        }
    }
}