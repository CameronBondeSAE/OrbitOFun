using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;
using LukeBaker;
using System.Linq;

public class CamMode : GameModeBase
{
	public List<GravitationalObject> gravObjects;
	
	public void Start()
	{
		// gravObjects = new List<GravitationalObject>();
	}
	
	public void DoThing()
	{
		gravObjects = FindObjectsOfType<GravitationalObject>().ToList();
	}
	
	public override void Activate()
	{
		base.Activate();
		
		Debug.Log("CamMode Activate");
	}
}
