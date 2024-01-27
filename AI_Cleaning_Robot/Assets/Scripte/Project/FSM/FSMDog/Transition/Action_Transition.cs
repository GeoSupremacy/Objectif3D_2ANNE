using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Action_Transition", menuName = "FSM/Transition/Dog_Transition/Create Action_Transition")]
public class Action_Transition : Transition
{
    public override bool IsValisTransition()
    {
        DogRobot _currentDog = (DogRobot)CurrentFSM.Robot;
        return true;
    }
}
