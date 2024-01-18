using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class State_Robot_Clean : State
{
    /*
    [SerializeField]
    protected CleanTransition[] transitions = null;
    public FSM_Robot_Clean FSM { get; set; }
    protected List<CleanTransition> runningTransitions = new List<CleanTransition>();
    public virtual void StartState(FSM_Robot_Clean _fms)
    {

        InitTransitions();
        Debug.Log("Start: " + name);
        FSM = _fms;
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
            CleanTransition _transition = Instantiate(transition);
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
    */
}
