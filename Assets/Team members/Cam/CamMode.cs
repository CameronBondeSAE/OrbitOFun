using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;
using LukeBaker;
using System.Linq;

public class CamMode : GameModeBase
{
	public GameObject playablePrefab;
	
	public override void Activate()
	{
		base.Activate();
		
		FindObjectOfType<CustomNetworkManager>().SpawnPlayers();
		
		Debug.Log("CamMode Activate");
		CamsManagerWithSingleton.Instance.interestingInfo = 6;
		
		ActivateAllIGameModeInteractables();
	}
}
