using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamsPulsatingFun_UsingInterfaces : MonoBehaviour, IGameModeInteractable
{
	// Tip: You CAN use GetComponent<IYourInterface>(), but you CAN'T use FindObject (because it's not an object, it's a component OF an object)
	public void Activate()
	{
		Debug.Log("CamsPulsatingFun_UsingInterfaces activate via interface");
	}
}
