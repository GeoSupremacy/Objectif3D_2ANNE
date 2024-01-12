using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "FSM", menuName = "FSM/ Create FSM")]
public class FSM : ScriptableObject
{
    [SerializeField]
    private State EnterState = null;
    [SerializeField]
    private State currentState = null;
    public FSMComponent CurrentFSMComponent { get;  private set; }
    public RobotClean Robot =>CurrentFSMComponent.Owner;
    bool instanciate =false;
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
    public void StartSFM(FSMComponent _fs)
    {
        if(EnterState == null)
            new System.NullReferenceException(name+ "FSM Not Enter State");
         
        if (_fs == null)
            new System.NullReferenceException(name + "FSM Not FSMComponent State");
           
        
        CurrentFSMComponent = _fs;
        instanciate = true;
        EnterState = Instantiate(EnterState);
        SetNextState(EnterState);
    }
    public void Update()
    {
        currentState?.StateUpdate();
    }
    public void StopFSM()
    {
        currentState?.Exit();
        currentState = null;
    }

}
