using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class InputComponent : MonoBehaviour
{
    [SerializeField] InputPlayer inputs = null;
    [SerializeField] InputAction moveForward = null;

    List<InputAction> actions = new List<InputAction>();
    public InputAction MoveForward => moveForward;
    private void Awake() => inputs = new InputPlayer();

    private void OnEnable()
    {
        moveForward = inputs.Player.Moveforward;
        actions.AddRange(new List<InputAction> { moveForward });
        ManageInputActivate(true);
    }
    private void OnDisable()
    {
        ManageInputActivate(false);
    }

    public void ManageInputActivate(bool _value)
    {
        foreach (InputAction input in actions)
        {
            if (_value)
                input.Enable();
            else
                input.Disable();
        }
    }
}
