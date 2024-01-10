using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_Corr : ScriptableObject
{
    public event Action OnStart = null, OnUpdate = null, OnExit = null;
    [field: SerializeField] public FSM_Corr FSM { get; private set; }
    [SerializeField] public Transition_Corr[] transitions = null;
   protected List<Transition_Corr> runningTransitions = new();
    public virtual void Enter(FSM_Corr fsm)
    {
        FSM = fsm;
        InitTransitions();
        OnStart?.Invoke();
        Debug.Log("Enter "+ name);
    }

    public virtual void Update()
    {
        CheckIsValidTransition();
        OnUpdate?.Invoke();
        Debug.Log("Update " + name);
    }

    public virtual void Exit()
    {
        OnExit?.Invoke();
        Debug.Log("Exit " + name);
        FSM = null;
    }

    protected virtual void InitTransitions()
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            Transition_Corr _tr = Instantiate(transitions[i]);
            _tr.InitTransition(FSM);
            runningTransitions.Add(_tr);
        }
    }

    protected virtual void CheckIsValidTransition()
    {
        for(int i = 0;i < runningTransitions.Count;i++) 
            if (runningTransitions[i].IsValidTransition)
            {
                Debug.Log("CheckIsValidTransition " + name);
                FSM.SetNextState(runningTransitions[i].NextState);
                Exit();
                return;
            }
        
    }
}
