using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    [SerializeField] InputPlayer inputs = null;
    [SerializeField] InputAction moveForward = null;
    [SerializeField] InputAction testServe = null;
    [SerializeField] InputAction testClient = null;
    List<InputAction> actions = new List<InputAction>();


    public InputAction MoveForward => moveForward;
    public InputAction TestServe => testServe;
    public InputAction TestClient => testClient;


    private void Awake() => inputs = new InputPlayer();

    private void OnEnable()
    {
        moveForward = inputs.Player.Moveforward;
        testServe = inputs.Player.TestServerRpc;
        testClient = inputs.Player.TestClientRpc;
        actions.AddRange(new List<InputAction> { moveForward , testServe, testClient });
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
