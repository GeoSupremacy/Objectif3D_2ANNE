using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAnimation : StateMachineBehaviour
{
    [SerializeField]
        string nameState = "StateAnimation";
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEnter();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExist();
    }
    void StateEnter()=>
        Debug.Log(nameState + ": StateEnter Animation");
    void StateUpdate()=>
        Debug.Log(nameState + ": StateUpdate Animation");
    void StateExist()=>
        Debug.Log(nameState + ": StateExist Animation");
}
