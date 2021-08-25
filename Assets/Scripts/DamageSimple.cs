using RileyMcGowan;
using System;
using UnityEngine;

public class DamageSimple : MonoBehaviour
{
	public float amount           = 100000f;
	public bool  continuousDamage = true;

	void OnCollisionEnter(Collision other)
	{
		other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
	}

	void OnCollisionStay(Collision other)
	{
		if (continuousDamage)
		{
			other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		// HACK: InParent is dumb
		other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount, Health.DamageType.Normal);
	}

	void OnTriggerStay(Collider other)
	{
		if (continuousDamage)
		{
			other.gameObject.GetComponentInParent<Health>()?.DoDamage(amount * Time.fixedDeltaTime, Health.DamageType.Normal);
		}
	}
}