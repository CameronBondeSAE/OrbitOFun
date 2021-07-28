using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider volumeSlider;
    


    

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

        //mixer.SetFloat("MusicVolume", volumeSlider.value);
    }
}

