using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mood_Transition", menuName = "FSM/Transition/Dog_Transition/Create Mood_Transition")]
public class Mood_Transition : Transition
{

   

    public override void InitTransition(FSM _fsm)
    {
        if (_fsm == null)
        {
            Debug.Log("Transition: " + name + " as not FSM");
        }
        CurrentFSM = _fsm;
    }
    public override bool IsValisTransition()
    {
        return false;
    }
}
