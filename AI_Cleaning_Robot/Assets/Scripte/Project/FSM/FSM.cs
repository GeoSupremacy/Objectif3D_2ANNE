
using UnityEngine;

[CreateAssetMenu(fileName = "FSM", menuName = "FSM/FSM/Create FSM")]
public  class FSM : ScriptableObject
{
    [SerializeField]
    protected State EnterState = null;
    [SerializeField]
    protected State currentState = null;
    public FSMComponent CurrentFSMComponent { get; private set; }
    public Robot Robot => CurrentFSMComponent.Owner;
    protected bool instanciate = false;
    public virtual void StartSFM(FSMComponent _fs)
    {
        if (EnterState == null)
            new System.NullReferenceException(name + "FSM Not Enter State");

        if (_fs == null)
            new System.NullReferenceException(name + "FSM Not FSMComponent State");



        instanciate = true;
        EnterState = Instantiate(EnterState);
        SetNextState(EnterState);
        CurrentFSMComponent = _fs;
    }
    public void SetNextState(State _state)
    {
        if (_state == null)
            new System.NullReferenceException(name + "FSM Not Next State");

        if (instanciate)
        {
            currentState = _state;
            instanciate = false;
        }
        else
            currentState = Instantiate(_state);
        currentState?.StartState(this);
    }
    public virtual void Update()
    {
        currentState?.StateUpdate();
    }
    public virtual void StopFSM()
    {
        currentState?.Exit();
        currentState = null;
    }
}
