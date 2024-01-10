using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMObject: MonoBehaviour
{

    [SerializeField]
    private  State startingState = null;
    [SerializeField]
    private State currentState = null;
    [SerializeField, HideInInspector]
    FSMComponent component = null;
public FSMComponent Component =>component;
public void StartFSM(FSMComponent _owner)
{
        component = _owner;
        SetNextState(startingState);
    }
public void SetNextState(State _state)
    {
        if (_state==null)
            return;
        if (currentState !=null)
            currentState.Exit();
        currentState = _state;
        currentState.Enter(this);
    }
public virtual void UpdateFSM()
    {
        if (currentState == null)
            currentState.StateUpdate();
    }
public virtual void StopFSM()
    {
        if (currentState == null)
            return;
        currentState.Exit();
        currentState = null;
    }

}
