using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;



public class InputComponant : MonoBehaviour
{
    #region Input
    ControlPlayer inputActions;
    InputAction moveForward,
                moveRight,
                rotateYaw,
                rotatePitch,
                jump;
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

        actions.AddRange(new List<InputAction> { moveForward, moveRight, rotatePitch, rotateYaw, jump,});
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
