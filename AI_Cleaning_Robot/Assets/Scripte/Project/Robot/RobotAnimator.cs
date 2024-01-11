using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
public class AnimatorParams
{
    
    public static int IS_MOVE_PARAM = Animator.StringToHash("isMove"); 
    public static int COLECTED_PARAM = Animator.StringToHash("Colected");
    public static int IS_DEATH_PARAM = Animator.StringToHash("isDead");
    
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Robot))]
public class RobotAnimator : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool isDeath = false;

    [SerializeField]
    Robot currentRobot = null;
    private void Awake() => Bind();
   
    void Bind()
    {
        currentRobot = this.GetComponent<Robot>();
        currentRobot.onDeath += DeatAnimation;
    }
    
    void DeatAnimation()=> isDeath=true;

    
    private void Update()
    {
        // animator.SetBool(AnimatorParams.COLECTED_PARAM, currentRobot.);
        animator.SetBool(AnimatorParams.IS_DEATH_PARAM, isDeath);
        animator.SetBool(AnimatorParams.IS_MOVE_PARAM, currentRobot.Move);
    }

}
