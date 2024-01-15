using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "MoveToPoint_State", menuName = "FSM/State/Create MoveToPoint_State")]
public class MoveToPoint_State : State
{
   [SerializeField] 
    private NatigationZone zone;
    public override void StartState(FSM _fms)
    {
        base.StartState(_fms);
        zone = _fms.Robot.Zone;
        ChangeMovement();
    }
    void ChangeMovement()
    {
        if (!FSM ||!zone)
            return;

        zone.NextMove();
       //  float _x = Random.Range(-20, 20), _z = Random.Range(-20, 20);
       // Vector3 _nextMove = new(_x, 0, _z);
        FSM.Robot.Move = true;
        FSM.Robot.NextMove = zone.Move;
        FSM.Robot.Look();
    }
}
