using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class State_Shoot : State
{
    [SerializeField]
    private GameObject projectile = null;
    [SerializeField]
    private WaitProjectilKillTransition waitForKill = null;
    public override void Enter(FSMObject _owner)
    {
        base.Enter(_owner);
        if (!projectile)
            return;
        gameObject.GetComponent<Launcher>().AddForce();
        //waitForKill = new WaitProjectilKillTransition();
        if (waitForKill!= null)
            waitForKill.SendProjectile(projectile);
    }

protected override void InitTransitions() 
  {
        base.InitTransitions();
        for (int i = 0; i < transitions.Length; i++)
        {

            WaitProjectilKillTransition _wait = transitions[i].gameObject.GetComponent<WaitProjectilKillTransition>();
            if (_wait)
            {
                waitForKill = _wait;
                return;
            }

        }
    }
}
