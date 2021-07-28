using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Tom
{
    public class AudioSlider : MonoBehaviour
    {
        public AudioMixer mixer;
        public string parameterName;
    
        public void SetVolume(float sliderValue)
        {
            mixer.SetFloat(parameterName, Mathf.Log10(sliderValue) * 20);
        }
    }
}