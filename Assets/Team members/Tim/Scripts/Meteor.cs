using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using RileyMcGowan;
using UnityEngine;

public class Meteor : CommonObject, IGameModeInteractable
{
    private Health health;
    private bool isActive = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Health>() == true)
        {
            health = other.gameObject.GetComponent<Health>();
            health.DoDamage(1, Health.DamageType.Normal);
        }
        DeathFunction();
    }

    public void Activate()
    {
        isActive = true;
    }

    public void DeathFunction()
    {
        NetworkServer.Destroy(gameObject);
    }
}
