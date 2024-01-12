using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
public class AnimatorParams
{
    
    public static int IS_MOVE_PARAM = Animator.StringToHash("isMove"); 
    public static int COLECTED_PARAM = Animator.StringToHash("Colected");
    public static int IS_DEATH_PARAM = Animator.StringToHash("isDead");
    
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RobotClean))]
public class RobotAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool iscollect = false;

    [SerializeField]
    RobotClean currentRobot = null;
    private void Awake() => Bind();
   
    void Bind()
    {
        currentRobot = this.GetComponent<RobotClean>();
        currentRobot.onDeathAnimation += DeathAnimation;
        currentRobot.onColllectAnimation += ColectedAnimation;
    }

    void ColectedAnimation(bool _isCollect) { animator.SetBool(AnimatorParams.COLECTED_PARAM, _isCollect); iscollect = _isCollect; }
    void DeathAnimation() => animator.SetBool(AnimatorParams.IS_DEATH_PARAM, true);
    void MoveAnimation() { if (!iscollect) animator.SetBool(AnimatorParams.IS_MOVE_PARAM, currentRobot.Move); }
    private void Update() => MoveAnimation();

}
