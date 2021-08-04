using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BezierCurve : MonoBehaviour
{
  public Transform point1;
  public Transform point2;
  public Transform point3;
  public Transform point4;

  public bool forward;

  public float speed;
  





  private Vector2 curvePoint;
  
  [Range(0f,1f)]
  public float time;


   private void Update()
   {
       if (forward)
       {
           Forward();
       }
   }

   void Forward()
   {
       Debug.Log("forward  ");
       while (time <= 1)
       {
           time += speed * Time.deltaTime;
           if (time > 1)
           {
               print("finished");
           }
       }
   }
   


   public void OnDrawGizmosSelected()
   {
       Vector2 pointA = Vector2.Lerp(point1.position, point2.position, time);
       Vector2 pointB = Vector2.Lerp(point2.position, point3.position, time);
       Vector2 pointC = Vector2.Lerp(point3.position, point4.position, time);
       Vector2 pointD = Vector2.Lerp(pointA, pointB, time);
       Vector2 pointE = Vector2.Lerp(pointB, pointC, time);
     
       curvePoint = Vector2.Lerp(pointD, pointE, time);
       Gizmos.DrawSphere(curvePoint, .3f);
   }
}
