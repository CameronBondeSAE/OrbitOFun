using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamsManagerWithSingleton : MonoBehaviour
{
	public int interestingInfo;


	// Singleton
	static CamsManagerWithSingleton instance;

	public static CamsManagerWithSingleton Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject go = new GameObject("CamsManager");
				instance = go.AddComponent<CamsManagerWithSingleton>();
			}

			return instance;
		}
		set { instance = value; }
	}


	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}
}