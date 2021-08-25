using Mirror;
using RileyMcGowan;
using System;
using UnityEngine;

public class DamageSimple : NetworkBehaviour
{
	public float amount = 100000f;

	public bool continuousDamage = true;

	void OnCollisionEnter(Collision other)
	{
		if (isServer)
		{
			other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (isServer)
		{
			if (continuousDamage)
			{
				other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (isServer)
		{
			// HACK: InParent is dumb
			other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (isServer)
		{
			if (continuousDamage)
			{
				other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount * Time.fixedDeltaTime, Health.DamageType.Normal);
			}
		}
	}
}