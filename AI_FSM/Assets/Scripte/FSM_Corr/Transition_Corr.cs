using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition_Corr : ScriptableObject
{
    [field: SerializeField] public State_Corr NextState { get; private set; } = null;
    protected FSM_Corr fsmOwner = null;
    public virtual bool IsValidTransition { get; } = false;
   public virtual void InitTransition(FSM_Corr _fsm)=> fsmOwner = _fsm;
}
