
using UnityEditor.PackageManager;
using UnityEngine;

[CreateAssetMenu(fileName = "FSM", menuName = "FSM/FSM/Create FSM")]
public  class FSM : ScriptableObject
{
    [field:SerializeField]
    protected State EnterState { get; private set; } = null;
   [SerializeField]
    protected State currentState = null;
    public FSMComponent CurrentFSMComponent { get; private set; }
    public Robot Robot => CurrentFSMComponent.Owner;
   
    public bool IsInfo { get; private set; } = true;
    public virtual void StartSFM(FSMComponent _fs)
    {
        if (EnterState == null)
            new System.NullReferenceException(name + "FSM Not Enter State");

        if (_fs == null)
            new System.NullReferenceException(name + "FSM Not FSMComponent State");
        CurrentFSMComponent = _fs;
        IsInfo =CurrentFSMComponent.IsInfo;
        SetNextState(EnterState);
       
    }
    public virtual void SetNextState(State _state)
    {
        
        if (_state == null)
            new System.NullReferenceException(name + "FSM Not Next State");
        currentState = Instantiate(_state);
        currentState.Enter(this);
    }
    public virtual void Update()=> currentState?.StateUpdate();
    
    public virtual void StopFSM()
    {
        currentState?.Exit();
        currentState = null;
    }
}
