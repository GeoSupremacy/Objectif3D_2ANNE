using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DetectedTransition", menuName = "FSM/Transition/TransitionClearRobot/Create DetectedTransition")]
public class DetectedTransition : Transition
{
    public override bool IsValisTransition()
    {
        RobotClean _rbc =(RobotClean) CurrentFSM.Robot;
        return _rbc.Garbage;
        
    }
}
