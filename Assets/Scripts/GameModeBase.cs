using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeBase : MonoBehaviour
{
	public virtual void Activate()
	{
		Debug.Log("GameModeBase Activate");
	}
}
