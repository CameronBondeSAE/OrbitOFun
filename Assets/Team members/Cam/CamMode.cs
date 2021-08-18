using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;
using LukeBaker;
using Mirror;
using System.Linq;
using Tom;

public class CamMode : GameModeBase
{
	// HACK: Should restrict to prefab with PlayerBase script.
	public GameObject playablePrefab;

	public CameraBase cameraPrefab;
	
	public override void Activate()
	{
		base.Activate();
		
		Debug.Log("CamMode Activate");

		CustomNetworkManager customNetworkManager = FindObjectOfType<CustomNetworkManager>();
		customNetworkManager.SpawnPlayers();

		PlayerBase playerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>();
		playerBase.rigidBody.isKinematic = true;
		// playerBase.EnableControls();
		
		PlayerArrow playerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>();
		playerArrow.EnableControls();
		
		
		ActivateAllIGameModeInteractables();

		// CustomNetworkManager networkManager = (CustomNetworkManager)NetworkManager.singleton;

		if (cameraPrefab != null)
		{
			CameraBase cam = Instantiate(cameraPrefab);
			cam.AssignTarget(NetworkClient.localPlayer.GetComponent<Transform>());
		}
	}
}
