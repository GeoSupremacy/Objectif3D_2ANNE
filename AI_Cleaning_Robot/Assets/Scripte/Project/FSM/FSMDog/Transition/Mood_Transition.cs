using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mood_Transition", menuName = "FSM/Transition/Dog_Transition/Create Mood_Transition")]
public class Mood_Transition : Transition
{

  
    public override bool IsValisTransition()
    {
      DogRobot _currentDog = (DogRobot) CurrentFSM.Robot;
        return _currentDog.IsSavage;
    }
}
