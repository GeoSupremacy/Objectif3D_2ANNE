using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : ScriptableObject
{
   public FSM FSM { get; set; } = null;
    [SerializeField]
    private Transition[] transitions = null;
    
   private List<Transition> runningTransitions = new List<Transition>();
   public virtual void StartState(FSM _fms)
    {
        FSM = _fms;
        InitTransitions();
        Debug.Log("Start: " + name);
    }
   public virtual void StateUpdate()
    {
        Debug.Log("Update: " + name);
        CheckTransitions();
        
    }
   public void Exit()
    {
        FSM = null;
        
        Debug.Log("Exit: " + name);
    }
   private void InitTransitions()
    {
        runningTransitions.Clear();
        foreach (var transition in transitions)
        {
            Transition _transition = Instantiate(transition);
            _transition.InitTransition(FSM);
            runningTransitions.Add(_transition);
        }
    }
   private void CheckTransitions()
    {
        foreach (var transition in runningTransitions)
        {
            if (transition == null)
                continue;
            if (transition.IsValisTransition())
            {
                Debug.Log(transition.name+" " + name+ " to "+ transition.NextState);
   
                FSM?.SetNextState(transition?.NextState);
                Exit();
                return;
            }
        }
    }
}
