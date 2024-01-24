using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "MoveToPoint_State", menuName = "FSM/State/Create MoveToPoint_State")]
public class MoveToPoint_State : State
{
    
   [SerializeField] 
    private Navigator zone;
    public override void Enter(FSM _fms)
    {
        base.Enter(_fms);
        zone = _fms.Robot.Zone;
        ChangeMovement();
    }
    void ChangeMovement()
    {
        if (!FSM ||!zone)
            return;
        
        zone.NextMove();
        FSM.Robot.Move = true;
        FSM.Robot.NextMove = zone.Move;
        FSM.Robot.Look();
    }
    
}
