using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zach;

public class EndTrigger : MonoBehaviour
{
    public event Action GoalReached;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            GoalReached?.Invoke();
        }
    }
}
