using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBase : MonoBehaviour
{
    public virtual void Activate()
    {
        Debug.Log("Activating Gamemode");
    }
}
