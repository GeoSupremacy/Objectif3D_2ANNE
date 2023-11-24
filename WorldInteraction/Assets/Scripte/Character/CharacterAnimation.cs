using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorParams
{
    // public const string SPEED_PARAM = "speed";
    public static int SPEED_FORWARD__PARAM = Animator.StringToHash("speedForward"); //For Unity
    public static int SPEED_RIGHT_PARAM = Animator.StringToHash("speedRight"); 
}








public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] AnimationCurve curveSpeed = null;
    [SerializeField] CharacterController controller = null;
     float axisForward, axisRight;

     Action<float> OnMoveForward = null;
    Action<float> OnMoveRight = null;

    private void Awake()
    {
       
        OnMoveForward += MoveForward;
        OnMoveRight += MoveRight;
    }
  
    private void Update()
    {
        UpdateAnimation();
    }

    private void MoveForward(float _speed)
    {
        axisForward = _speed;
        axisRight = 0;
        animator.SetFloat(AnimatorParams.SPEED_FORWARD__PARAM, axisForward, 0.5f, Time.deltaTime);
        controller.SimpleMove(transform.forward * _speed);
    }
    private void MoveRight(float _speed)
    {
        axisRight = _speed;
        if(axisForward!=0)
            animator.SetFloat(AnimatorParams.SPEED_RIGHT_PARAM, axisRight, 0.5f, Time.deltaTime);
        controller.SimpleMove(transform.right * _speed);
    }
    void UpdateAnimation()
    {
        OnMoveForward?.Invoke(Input.GetAxis("Vertical"));
        OnMoveRight?.Invoke(Input.GetAxis("Horizontal"));


        // animator.SetFloat("Speed", Mathf.PingPong(Time.time,1), 2 , Time.deltaTime);
        // animator.SetFloat(AnimatorParams.SPEED_PARAM, curveSpeed.Evaluate(Time.time));
        //animator.SetFloat(AnimatorParams.SPEED_PARAM, _speed, 0.5f, Time.deltaTime);
    }
   
    
}
