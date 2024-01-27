using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Idle_State", menuName = "FSM/State/Create Idle_State")]
public class Idle_State : State
{

    public override void Enter(FSM _fms)
    {
        base.Enter(_fms);
        FSM.Robot.ClearnSight();
    }

}
