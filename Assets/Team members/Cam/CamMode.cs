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
	
	// [Server]
	public override void Activate()
	{
		base.Activate();
		
		Debug.Log("CamMode Activate");

		CustomNetworkManager customNetworkManager = FindObjectOfType<CustomNetworkManager>();
		customNetworkManager.SpawnPlayers();

		ActivateAllIGameModeInteractables();

		// PlayerBase playerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>();
		// playerBase.rigidBody.isKinematic = true;
		
		RpcEnableLocalPlayerControls();
	}

	// [ClientRpc]
	public void RpcEnableLocalPlayerControls()
	{
		PlayerBase playerBase = NetworkClient.localPlayer.GetComponentInChildren<PlayerBase>();
		playerBase.EnableControls();
		
		PlayerArrow playerArrow = NetworkClient.localPlayer.GetComponentInChildren<PlayerArrow>();
		// playerArrow.EnableControls();
		playerArrow.enabled = false;
		
		if (cameraPrefab != null)
		{
			CameraBase cam = Instantiate(cameraPrefab);
			cam.AssignTarget(NetworkClient.localPlayer.GetComponent<Transform>());
		}
	}
}
