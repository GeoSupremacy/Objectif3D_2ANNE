using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleanTransition", menuName = "FSM/Transition/Create CleanTransition")]
public class CleanTransition : Transition
{
    public override bool IsValisTransition()
    {
        return !CurrentFSM.Robot.Garbage;
    }
}
