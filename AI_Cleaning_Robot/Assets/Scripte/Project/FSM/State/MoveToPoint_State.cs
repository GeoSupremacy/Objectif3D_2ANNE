using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "MoveToPoint_State", menuName = "FSM/State/Create MoveToPoint_State")]
public class MoveToPoint_State : State
{

    public override void StartState(FSM _fms)
    {
        base.StartState(_fms);
        ChangeMovement();
    }
    void ChangeMovement()
    {
        if (!FSM)
            return;

        float _x = Random.Range(-20, 20), _z = Random.Range(-20, 20);
        FSM.Robot.Move = true;
        FSM.Robot.NextMove = new(_x, 0, _z);
        FSM.Robot.Look();
    }
}
