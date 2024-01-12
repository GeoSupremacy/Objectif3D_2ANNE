using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DetectedTransition", menuName = "FSM/Transition/Create DetectedTransition")]
public class DetectedTransition : Transition
{
    public override bool IsValisTransition()
    {
        return CurrentFSM.Robot.Garbage;
        
    }
}
