using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : ScriptableObject
{
    [SerializeField]
    private string textArea;
    [SerializeField]
    protected Transition[] transitions = null;
    [field: SerializeField]

    public bool IsInfoState { get; private set; } = true;
    public FSM FSM { get; set; }
    protected List<Transition> runningTransitions = new List<Transition>();
   public virtual void Enter(FSM _fms)
    {
        FSM = _fms;
        IsInfoState = FSM.IsInfo;
        if (IsInfoState)
        Debug.LogAssertion("Start: " + name);
       

        InitTransitions();
     
    }
   public virtual void StateUpdate()
    {
        if (IsInfoState)
            Debug.LogWarning("Update: " + name);
        CheckTransitions();
        
    }
   public virtual void Exit()
    {

        FSM = null;
        if (IsInfoState)
            Debug.LogError("Exit: " + name);
    }
   protected virtual void InitTransitions()
    {
        
        runningTransitions.Clear();
      
        foreach (var transition in transitions)
        {
            Transition _transition = Instantiate(transition);
            _transition.InitTransition(FSM);
            runningTransitions.Add(_transition);
        }
    }
    protected virtual void CheckTransitions()
    {
        foreach (var transition in runningTransitions)
        {
            if (transition == null)
                continue;
            if (transition.IsValisTransition())
            {
                if (IsInfoState)
                    Debug.Log(transition.name + " " + name + " to " + transition.NextState);
              
                FSM?.SetNextState(transition?.NextState);
                Exit();
                return;
            }
        }
    }
    
}
