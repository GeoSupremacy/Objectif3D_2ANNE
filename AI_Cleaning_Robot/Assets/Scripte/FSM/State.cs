using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "State", menuName = "FSM/State/Create State")]
public class State : ScriptableObject
{
   public FSM FSM { get; set; } = null;
   public void StartState(FSM _fms)
    {
        FSM = _fms;
        Debug.Log("Start: " + name);
    }

  
   public void StateUpdate()
    {
        Debug.Log("Update: " + name);
    }
    public void Exit()
    {
        FSM = null;
        Debug.Log("Exit: " + name);
    }
}
