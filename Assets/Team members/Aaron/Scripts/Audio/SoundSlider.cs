using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string volumeToChange;
    
    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat(volumeToChange, Mathf.Log10(sliderValue) * 20);
    }
}
