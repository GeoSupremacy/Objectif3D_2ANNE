using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State: MonoBehaviour 
{
   [SerializeField, HideInInspector]
    protected FSMObject currentFSMObject = null;
   [SerializeField]
   protected Transition[] transitions ={};
  // [SerializeField]
   //protected UPROPERTY(VisibleAnywhere, meta = (EditInLine)) TArray<TObjectPtr<class UTransition>> runningTransitions = {};
public virtual void Enter(FSMObject _owner)
{
        currentFSMObject = _owner;
        InitTransitions();
    }
public virtual void StateUpdate()
    {
        CheckForValidTransition();
    }
public virtual void Exit()
    {
        currentFSMObject = null;
    }
protected virtual void InitTransitions()
    {
        foreach(var transition in transitions)
        {
            if (transition == null)
                continue;
            Transition _transition = transition;
            //UDumTrans _dm = Cast<uDm>(tr)
            //if (_dm) = do
            _transition.InitTranstition();//???
        }
    }
protected void CheckForValidTransition()
    {
        foreach (var transition in transitions)
        {
            if (transition.IsValidTranstition())
            {
                currentFSMObject.SetNextState(transition.NextState);
                Exit();
                return;
            }
        }
    }
}
