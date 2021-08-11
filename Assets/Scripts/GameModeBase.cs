using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zach
{
	public class GameModeBase : MonoBehaviour
	{
		public List<string> levels;
		public string gameModeName;
		public string description; 
		public virtual void Activate()
		{
			Debug.Log("GameModeBase Activate");
		}

		public void ActivateAllIGameModeInteractables()
		{
			// Interfaces AREN'T objects themselves, so FindObjects don't work,
			// unless you find a normal inherited class first, THEN get the component 
			foreach (CommonObject commonObject in FindObjectsOfType<CommonObject>())
			{
				commonObject.GetComponent<IGameModeInteractable>()?.Activate();
			}
		}
	}
}
