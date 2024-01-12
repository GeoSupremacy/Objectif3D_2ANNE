using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Clean_State", menuName = "FSM/State/Create Clean_State")]
public class Clean_State : State
{
    public override void Exit()
    {
        Debug.Log("EndCollected");
        FSM.Robot.EndCollected();
        base.Exit();
      
    }
}
