using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class WaitProjectilKillTransition : Transition
{
    [SerializeField, HideInInspector]
        GameObject currentProjectile = null;
    public void SendProjectile(GameObject _projectile)
    {

    }
    public override bool IsValidTranstition()
    { 
        return false; 
    }
}
