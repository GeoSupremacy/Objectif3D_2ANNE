using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent_CleanRobot : FSMComponent
{
     [SerializeField] private FSM_Robot_Clean FSM_Robot_Clean;
    [field: SerializeField] new public  RobotClean Owner { get; set; }
  
}
