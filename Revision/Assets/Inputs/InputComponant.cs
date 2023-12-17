using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;
using UnityEngine.UIElements;



public class InputComponant : MonoBehaviour
{
    #region Input
    [SerializeField,HideInInspector]
    ControlPlayer inputActions;
    [SerializeField, HideInInspector]
    InputAction moveForward,
                moveRight,
                rotateYaw,
                rotatePitch,
                jump,
                interact,
                leftchat;
    List<InputAction> actions = new();
    #endregion Input

    #region METHOD_UNITY
    private void Awake() => BindMapping();
 
    private void OnEnable() => BindAction();

    private void OnDisable() => ManageInputActivate(false);
    #endregion METHOD_UNITY

    #region Acesseur
    List<InputAction> AllActions =>actions;
    public InputAction MoveForward => moveForward;
    public InputAction MoveRight => moveRight;
    public InputAction RotateYaw => rotateYaw;
    public InputAction RotatePitch => rotatePitch;
    public InputAction Jump => jump;
    public InputAction Interact => interact;

    public InputAction Leftchat => leftchat;
    #endregion Acesseur

    #region MANAGE_INPUT
    void BindMapping() => inputActions = new ControlPlayer();
    void BindAction()
    {
        moveForward = inputActions.Player.MoveVertical;
        moveRight = inputActions.Player.MoveHorizontal;
        rotatePitch = inputActions.Player.RotatePitch;
        rotateYaw = inputActions.Player.RotateYaw;
        jump = inputActions.Player.Jump;
        interact = inputActions.Player.Interaction;
        leftchat = inputActions.Player.leftChat;
        actions.AddRange(new List<InputAction> { moveForward, moveRight, rotatePitch, rotateYaw, jump, interact, leftchat ,});
        ManageInputActivate(true);
    }
    void ManageInputActivate(bool _activate)
    {
        foreach(var action in actions) 
            if(_activate)
                action.Enable();
             else 
                action.Disable();
    }
    #endregion MANAGE_INPUT
}
