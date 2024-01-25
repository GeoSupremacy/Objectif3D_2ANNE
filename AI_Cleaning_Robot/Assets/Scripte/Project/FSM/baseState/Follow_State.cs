using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Follow_State", menuName = "FSM/State/Create Follow_State")]
public class Follow_State : State
{

    public override void StateUpdate()
    {
      base.StateUpdate();

        FSM.Robot.Follow();

    }
}
