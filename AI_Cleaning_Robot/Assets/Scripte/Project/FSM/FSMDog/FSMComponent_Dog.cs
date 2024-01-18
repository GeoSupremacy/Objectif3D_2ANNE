using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMComponent_Dog : FSMComponent
{
    [SerializeField] private  FSM_Dog FSM;
    [field: SerializeField] public new  DogRobot Owner { get; set; }
   
}
