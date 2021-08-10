using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationFunctionTests : MonoBehaviour
{
	public Transform p1;
	public Transform p2;

	[Range(0,1f)]
	public float t;
	
	// Start is called before the first frame update
	void Start()
	{

	}

	public AnimationCurve curve;
	
	void OnDrawGizmos()
	{
		Vector3 lerp = Vector3.Lerp(p1.position, p2.position, t);

		Gizmos.DrawSphere(lerp, 1f);
		
		Debug.Log(curve.Evaluate(t));
	}

	public void PlaySound()
	{
		DestroyImmediate(gameObject);
		Debug.Log("BANG");
	}

	public void PlaySelectableSound(AnimationEvent huh)
	{
		// Debug.Log("Sound = "+clip.name);
	}

}
