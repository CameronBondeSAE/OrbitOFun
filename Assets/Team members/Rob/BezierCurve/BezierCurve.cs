using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BezierCurve : CommonObject, IGameModeInteractable 
{
  public Transform point1;
  public Transform point2;
  public Transform point3;
  public Transform point4;

  public bool forward;
  public bool backwards;

  public float speed;






  private Vector2 curvePoint;
  
  [Range(0f,1f)]
  public float time;


   private void Update()
   {
       if (InputSystem.GetDevice<Keyboard>().fKey.wasPressedThisFrame)
       {
           forward = true;
       }

       if (InputSystem.GetDevice<Keyboard>().bKey.wasPressedThisFrame)
       {

           backwards = true;

       }

       if (forward)
       {
           transform.rotation = Quaternion.Euler(point4.position.x, 0, point4.position.z);
           time += speed * Time.deltaTime;
           if (time >= 1)
           {
               forward = false;
               time = 1;
               backwards = true;
               
           }
       }

       if (backwards)
       {
           transform.rotation = Quaternion.Euler(point4.position.x, 180, point4.position.z);
           time -= speed * Time.deltaTime;
           if (time <= 0)
           {
               backwards = false;
               time = 0;
               forward = true;
               
           }
       }

       transform.position = curvePoint;
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

   public void Activate()
   {
       throw new NotImplementedException();
   }
}
