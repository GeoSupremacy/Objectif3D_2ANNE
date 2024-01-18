using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleanTransition", menuName = "FSM/Transition/TransitionClearRobot/Create CleanTransition")]
public class CleanTransition : Transition
{
    public override bool IsValisTransition()
    {
        RobotClean robotClean = (RobotClean)CurrentFSM.Robot;
        return !robotClean.Garbage;
    }
}
