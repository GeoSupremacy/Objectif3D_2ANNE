using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


public class AnimatorParams
{
    // public const string SPEED_PARAM = "speed";
    public static int SPEED_FORWARD_PARAM = Animator.StringToHash("speedForward"); //For Unity
    public static int SPEED_RIGHT_PARAM = Animator.StringToHash("speedRight");
}

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    float axisForward, axisRight;
  


    private void Awake() => Bind();
    private void Update() => UpdateAnimation();


    void UpdateAnimation()
    {

    }
    void MoveForward(float _axis) 
    {
       axisForward =_axis;
        animator.SetFloat(AnimatorParams.SPEED_FORWARD_PARAM, axisForward, 0, Time.deltaTime);
       
    }
    void Bind()
    {
        Player.onMoveForward += MoveForward;
    }
}
