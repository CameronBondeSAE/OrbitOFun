using RileyMcGowan;
using UnityEngine;

public class DamageSimple : MonoBehaviour
{
	public float amount = 100000f;
	bool         continuousDamage = true;

	void OnCollisionEnter(Collision other)
	{
		other.gameObject.GetComponent<Health>().DoDamage(amount, Health.DamageType.Normal);
	}

	void OnTriggerEnter(Collider other)
	{
		other.gameObject.GetComponent<Health>().DoDamage(amount, Health.DamageType.Normal);
	}

	void OnTriggerStay(Collider other)
	{
		if (continuousDamage)
		{
			other.gameObject.GetComponent<Health>().DoDamage(amount*Time.fixedDeltaTime, Health.DamageType.Normal);
		}
	}
}