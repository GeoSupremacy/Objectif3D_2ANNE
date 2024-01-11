using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : StateMachineBehaviour
{
     
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Robot _actuallyRobot= animator.gameObject.GetComponent<Robot>();
        _actuallyRobot.Dead();
    }
}
