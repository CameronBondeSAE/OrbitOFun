using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zach
{
	public class GameModeBase : MonoBehaviour
	{
		public List<string> levels;
		public virtual void Activate()
		{
			Debug.Log("GameModeBase Activate");
		}
	}
}
