using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName ="FSM", menuName="FSM/Create new FSM")]
public class FSM_Corr : ScriptableObject
{
    [field: SerializeField] public State_Corr InitState { get; private set; } = null;
    [field: SerializeField] public FSMComponent_Corr Owner { get; private set; }
    [SerializeField] State_Corr currentState = null;

    public virtual void SetNextState(State_Corr _state)
    {
        currentState = Instantiate(_state);
        currentState.Enter(this);
    }
    public virtual void StartFSM(FSMComponent_Corr _fsm)
    {
        Owner = _fsm;
        SetNextState(InitState);
    }
    public virtual void UpdateSFM()
    {
        currentState?.Update();
    }
    public virtual void StopFSM()
    {
        currentState?.Exit();
        currentState = null;
    }
}
