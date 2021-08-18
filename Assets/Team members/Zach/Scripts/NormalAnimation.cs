using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zach
{
    public class NormalAnimation : MonoBehaviour
    {

        public bool waiting;
        private Renderer _renderer;
        public float perlinNoise;
        public float range;
        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void FixedUpdate()
        {
            if (waiting != true)
            {
                StartCoroutine(AnimatedFresnelEffect());
            }
        }

        IEnumerator AnimatedFresnelEffect()
        {
            waiting = true;
            range = Random.Range(0,1f);
            perlinNoise = Mathf.PerlinNoise(range,range) * 10f;
            yield return new WaitForSeconds(.5f);
            _renderer.material.SetFloat("Fresnel_Effect", perlinNoise);
            waiting = false;
        }
    }
}
