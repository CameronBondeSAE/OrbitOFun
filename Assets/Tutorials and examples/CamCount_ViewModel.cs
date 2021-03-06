using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CamCount_ViewModel : MonoBehaviour
{
	// Model
	public CamsTests camsTests;

	// View
	public TextMeshProUGUI textMesh;


	void OnEnable()
	{
		// Subscribe to events here
	}

	void OnDisable()
	{
		// Unsubscribe to same events here (probably, eg if you have a state machine setup, do it there)
	}

	// Update is called once per frame
	void Update()
	{
		if (camsTests.fakeTimer < 10f)
		{
			textMesh.color = Color.red;
		}
		else
		{
			textMesh.color = Color.white;
		}

		textMesh.text = camsTests.fakeTimer.ToString("#");
	}
}