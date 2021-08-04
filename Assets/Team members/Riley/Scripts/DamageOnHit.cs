using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class DamageOnHit : MonoBehaviour
    {
        [Tooltip("Should the object hit increase mass")]
        public bool increaseMass;
        [Tooltip("Should the object hit increase size")]
        public bool increaseSize;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Gravity>() != null)
            {
                if (gameObject.GetComponent<CanGravitate>() != null)
                {
                    gameObject.GetComponent<CanGravitate>().OnDestroy();
                    if (increaseMass == true)
                    {
                        other.gameObject.GetComponent<Rigidbody>().mass += GetComponent<Rigidbody>().mass/5f;
                    }
                    if (increaseSize == true)
                    {
                        other.gameObject.transform.localScale += gameObject.transform.localScale/30f;
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}