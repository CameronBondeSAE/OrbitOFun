using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BezierShipEventListener : MonoBehaviour
{
	public Tom.BezierCurve BezierCurve;
	public Tom.BezierCurve BezierCurveDestination;


	void Awake()
	{
		BezierCurve.FinishedCurveEvent += OnBezierCurveOnFinishedCurveEvent;

		// BezierCurve.FinishedCurveUnityEvent.AddListener(OnBezierCurveOnFinishedCurveEvent);
		// BezierCurve.FinishedCurveUnityEvent2.AddListener(OnBezierCurveOnFinishedCurveEvent2);
	}

	public void OnBezierCurveOnFinishedCurveEvent2(int number, string name)
	{
		
	}

	public void OnBezierCurveOnFinishedCurveEvent()
	{
		BezierCurveDestination.PlayCurve();
	}

	public void DoThing()
	{
		
	}
}
