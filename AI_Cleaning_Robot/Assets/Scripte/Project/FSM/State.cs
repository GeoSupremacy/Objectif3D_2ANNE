using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : ScriptableObject
{
    
    [SerializeField]
    protected Transition[] transitions = null;
    [field: SerializeField]
    public FSM FSM { get; set; }
    protected List<Transition> runningTransitions = new List<Transition>();
   public virtual void Enter(FSM _fms)
    {
        Debug.Log("Start: " + name);
        FSM = _fms;
        InitTransitions();
     
    }
   public virtual void StateUpdate()
    {
        Debug.Log("Update: " + name);
        CheckTransitions();
        
    }
   public virtual void Exit()
    {

        FSM = null;
        Debug.Log("Exit: " + name);
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
                Debug.Log(transition.name + " " + name + " to " + transition.NextState);
              
                FSM?.SetNextState(transition?.NextState);
                Exit();
                return;
            }
        }
    }
    
}
