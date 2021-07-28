using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CamsTests : MonoBehaviour
{
	public float fakeTimer;

	public AudioSource sound;
	public AudioClip   clip;

	public AudioMixer mixer;

	public Slider slider;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		// Debug.Log("Slider = "+slider.value
		// mixer.SetFloat("MusicVolume", theVolumeTo);

		// if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		if(Random.value >0.97f)
		{
			sound.Play();

		}
	}
}