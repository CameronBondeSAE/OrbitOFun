using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RileyMcGowan
{
    public class DamageOnHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<Gravity>() != null)
            {
                if (gameObject.GetComponent<CanGravitate>())
                {
                    gameObject.GetComponent<CanGravitate>().OnDestroy();
                    Destroy(gameObject);
                }
            }
        }
    }
}