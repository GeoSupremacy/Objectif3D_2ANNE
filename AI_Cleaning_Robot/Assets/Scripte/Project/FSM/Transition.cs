using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : ScriptableObject
{
    [field:SerializeField]
    public State NextState { get; private set; }
    protected  FSM CurrentFSM{ get;  set; }
    public virtual void InitTransition(FSM _fsm)
    {
        if (_fsm == null)
        {
            Debug.Log("Transition: " + name+ " as not FSM");
        }
        CurrentFSM = _fsm;
    }
    public virtual bool IsValisTransition()
    { 
        return false;
    }
}
