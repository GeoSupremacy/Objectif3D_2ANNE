using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "FSM", menuName = "FSM/ Create FSM")]
public class FSM : ScriptableObject
{
    [SerializeField]
    private State Enter = null;
    [SerializeField]
    private State currentState = null;

    public void SetNextState(State _state) 
    { 
        currentState = _state;

        currentState?.StartState(this);
    }
   public void StartSFM()
    {
        if(Enter == null)
        {
            new System.NullReferenceException(name+ "FSM Not Enter State");
            return;
        }
        Enter =Instantiate(Enter);
        SetNextState(Enter);
    }
    public void Update()
    {
        currentState?.StateUpdate();
    }
    private void OnDestroy()
    {
        currentState?.Exit();
    }
}
