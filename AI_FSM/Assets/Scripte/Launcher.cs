using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] float lifeSpan = 2;
    [SerializeField] Rigidbody projectile = null;
    [SerializeField, Range(-100, 100)]
    private float xThrust,
                   yThrust,
                   zThrust;
    Vector3 ForceDirection() => new Vector3(xThrust, yThrust, zThrust);
   public void AddForce()
    {
        Destroy(gameObject, lifeSpan);
        if (projectile != null)
             projectile.AddForce(ForceDirection(), ForceMode.Impulse);
       
    }
}
