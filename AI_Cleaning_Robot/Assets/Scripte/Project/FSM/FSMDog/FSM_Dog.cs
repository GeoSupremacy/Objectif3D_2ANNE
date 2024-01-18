using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FSM_Dog", menuName = "FSM/FSM_Dog/ Create FSM_Dog")]
public class FSM_Dog : FSM
{
   
    public new FSMComponent_Dog CurrentFSMComponent { get; private set; }
    public new DogRobot Robot => CurrentFSMComponent.Owner;
   
   
}
