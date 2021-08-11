using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;
using LukeBaker;
using System.Linq;

public class CamMode : GameModeBase
{
	public override void Activate()
	{
		base.Activate();
		
		Debug.Log("CamMode Activate");
		CamsManagerWithSingleton.Instance.interestingInfo = 6;
		
		ActivateAllIGameModeInteractables();
	}
}
