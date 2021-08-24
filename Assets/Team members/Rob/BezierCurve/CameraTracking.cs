using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : CameraBase
{

   public Transform shipTransform;
   public float speed;
   public Vector3 offSet;
   public float velocityMultiplier;


   public override void AssignTarget(Transform target)
   {
      base.AssignTarget(target);
      shipTransform = target;

   }

   private void FixedUpdate()
   {
      Vector3 cameraPos = shipTransform.position + offSet;
      Vector3 smoothPos = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime * speed);
      transform.position = smoothPos;
   }

   /*private void LateUpdate()
   {
      float xVel = shipTransform.GetComponent<Rigidbody>().velocity.x * velocityMultiplier;
   }*/

   /*private void Update()
   {
      if (shipTransform != null)
      {
         transform.position = Vector2.Lerp(transform.position, shipTransform.position, speed);
      }
   }*/
}
