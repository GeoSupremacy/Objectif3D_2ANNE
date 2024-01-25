using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LostTarget_Transition", menuName = "FSM/Transition/Create LostTarget_Transition")]

public class LostTarget_Transition : Transition
{
    public override bool IsValisTransition()
    {
      
        return CurrentFSM.Robot.LostTarget;

    }
}
