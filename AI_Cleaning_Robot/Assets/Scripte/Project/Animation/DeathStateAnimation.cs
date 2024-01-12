using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStateAnimation : StateAnimation
{
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        RobotClean _actuallyRobot= animator.gameObject.GetComponent<RobotClean>();
        _actuallyRobot.Dead();
    }
}
