using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zach
{
    public class BlackHole : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.transform.position = new Vector3(Random.Range(0f, 10f), Random.Range(0f, 10f), 0);
        }
    }
}
