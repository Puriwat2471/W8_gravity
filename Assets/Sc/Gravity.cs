using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   private Rigidbody rb;
   private const float G = 0.006674f;
   public static List<Gravity> gravityObjectList;

   private bool planets = false;
   private int orbetSpeed = 1000;

   private void Awake()
   {
      rb = GetComponent<Rigidbody>();

      if (gravityObjectList == null)
      {
         gravityObjectList = new List<Gravity>();
      }
      
      gravityObjectList.Add(this);

      if (!planets)
      {
         rb.AddForce(Vector3.left * orbetSpeed);
      }
   }

   private void FixedUpdate()
   {
      foreach (var obj in gravityObjectList)
      {
         if (obj != null)
         {
            Attrack(obj);
         }
      }
   }

   void Attrack(Gravity other)
   {
      Rigidbody otherRb = other.rb;
       
      //find distance between two objects
      Vector3 direction = rb.position - otherRb.position;
      float distance = direction.magnitude;
      float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
      Vector3 finalForce = forceMagnitude * direction.normalized;

      //addforce
      otherRb.AddForce(finalForce);

   }
}
