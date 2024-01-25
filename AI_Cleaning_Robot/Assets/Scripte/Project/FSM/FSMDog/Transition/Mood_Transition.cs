using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mood_Transition", menuName = "FSM/Transition/Dog_Transition/Create Mood_Transition")]
public class Mood_Transition : Transition
{

  
    public override bool IsValisTransition()
    {
        DogRobot _dog = (DogRobot)CurrentFSM.Robot;
        return true;
    }
}
