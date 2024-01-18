using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FSM_Robot_Clean", menuName = "FSM/FSM_Robot_Clean /Create FSM_Robot_Clean")]
public class FSM_Robot_Clean : FSM
{
    
    public new FSMComponent_CleanRobot CurrentFSMComponent { get; private set; }
    public new RobotClean Robot => CurrentFSMComponent.Owner;
   
}//
