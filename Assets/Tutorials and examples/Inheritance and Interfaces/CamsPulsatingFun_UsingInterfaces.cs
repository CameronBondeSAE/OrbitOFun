using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamsPulsatingFun_UsingInterfaces : MonoBehaviour, IGameModeActivatable
{

	public void Activate()
	{
		Debug.Log("CamsPulsatingFun_UsingInterfaces activate via interface");
	}
}
