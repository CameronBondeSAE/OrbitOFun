using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace Rob
{
    public class MusicManager : MonoBehaviour
    {
        public AudioSource sound;

        private void Update()
        {
            
            if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
            {
                sound.Play();
            }
        }
        
    }
}
