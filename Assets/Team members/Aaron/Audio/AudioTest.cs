using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor.Drawers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class AudioTest : MonoBehaviour
{
    public AudioSource sound;
    public AudioSource effect;

    public AudioMixer mixer;
    
    void Update()
    {
        if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
        {
            sound.Play();
            mixer.SetFloat("MasterVolume", 1f);
        }

        if (InputSystem.GetDevice<Keyboard>().vKey.wasPressedThisFrame)
        {
            effect.Play();
        }
    }
}
