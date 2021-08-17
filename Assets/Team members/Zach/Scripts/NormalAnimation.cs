using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zach
{
    public class NormalAnimation : MonoBehaviour
    {
        private Renderer _renderer;
        public float perlinNoise;
        public float range;
        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            range = Random.Range(0,1f);
            perlinNoise = Mathf.PerlinNoise(range,range);
            _renderer.material.SetFloat("Fresnel_Effect", perlinNoise);
        }
    }
}
