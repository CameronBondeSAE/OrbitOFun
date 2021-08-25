using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

public class EndTrigger : MonoBehaviour
{
    public event Action TriggerEnterEvent;
    public bool isPlayer = true;
    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (other.GetComponentInParent<PlayerBase>())
            {
                TriggerEnterEvent?.Invoke();
            }
        }
        else
        {
            TriggerEnterEvent?.Invoke();
        }
    }
}
