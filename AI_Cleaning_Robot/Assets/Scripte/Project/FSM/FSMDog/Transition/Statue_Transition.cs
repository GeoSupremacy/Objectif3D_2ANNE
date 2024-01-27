using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Statue_Transition", menuName = "FSM/Transition/Dog_Transition/Create Statue_Transition")]
public class Statue_Transition : Transition
{

    public override bool IsValisTransition()
    {
        DogRobot _dog = (DogRobot)CurrentFSM.Robot;

        return _dog.IsSavage;
    }
}
