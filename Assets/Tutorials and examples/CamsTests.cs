using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zach;

public class CamsTests : GameModeBase
{
	public float fakeTimer;

	public AudioSource sound;
	public AudioClip   clip;

	public AudioMixer mixer;

	public Slider slider;
	bool          started;


	public override void Activate()
	{
		base.Activate();
		
		Debug.Log("Cams mode has been activated");

		started = true;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!started)
		{
			return;
		}

		// Debug.Log("Slider = "+slider.value
		// mixer.SetFloat("MusicVolume", theVolumeTo);

		// if (InputSystem.GetDevice<Keyboard>().spaceKey.wasPressedThisFrame)
		if(Random.value >0.97f)
		{
			sound.Play();

		}
	}
}