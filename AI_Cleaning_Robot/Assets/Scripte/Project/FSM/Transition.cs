using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : ScriptableObject
{
    [field: SerializeField]
    private string textArea;

    [field:SerializeField]
    public State PreviousState { get;  set; }
    public State NextState { get; private set; }
    protected  FSM CurrentFSM{ get;  set; }
  
    public virtual void InitTransition(FSM _fsm)
    {
        CurrentFSM = _fsm;
    }
    public virtual bool IsValisTransition()
    { 
        return false;
    }
    
}
