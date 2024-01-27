using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent : MonoBehaviour
{
    [SerializeField] InputPlayer inputs = null;
    [SerializeField] InputAction actionAgressif = null;

    List<InputAction> actions = new List<InputAction>();
    public InputAction ActionAgressif => actionAgressif;

    private void Awake()
    {
        inputs = new InputPlayer();
    }

    private void OnEnable()
    {
        actionAgressif = inputs.PlayerControllerMap.Agrresif;
        //TODO map
        actions.AddRange(new List<InputAction> { actionAgressif,  });
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
