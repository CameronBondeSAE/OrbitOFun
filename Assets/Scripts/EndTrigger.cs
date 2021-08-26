using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

public class EndTrigger : MonoBehaviour
{
    public event Action<PlayerBase> PlayerTriggerEnterEvent;
    public event Action<GameObject> TriggerEnterEvent;
    public bool isPlayer = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (other.GetComponentInParent<PlayerBase>())
            {
                PlayerTriggerEnterEvent?.Invoke(other.GetComponentInParent<PlayerBase>());
            }
        }
        else
        {
            TriggerEnterEvent?.Invoke(other.transform.root.gameObject);
        }
    }
}
