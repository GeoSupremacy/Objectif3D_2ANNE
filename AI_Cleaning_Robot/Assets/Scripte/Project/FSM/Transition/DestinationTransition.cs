using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DestinationTransition", menuName = "FSM/Transition/Create DestinationTransition")]
public class DestinationTransition : Transition
{
    public override bool IsValisTransition()
    {
        return CurrentFSM.Robot.Destination();
    }
}
