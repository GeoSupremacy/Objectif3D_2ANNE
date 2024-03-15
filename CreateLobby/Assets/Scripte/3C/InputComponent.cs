using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputComponent : MonoBehaviour
{
    [SerializeField] InputPlayer inputPlayer = null;

    [SerializeField] InputAction openChat = null;
    [SerializeField] InputAction readMessage = null;
    [SerializeField] InputAction moveForward = null;
    [SerializeField] InputAction moveRight = null;

    [SerializeField] List<InputAction> actions = null;
    public InputAction OpenChat => openChat;
    public  InputAction ReadMessage => readMessage;
    public InputAction MoveForward => moveForward;
    public InputAction MoveRight => moveRight;
    private void Awake()
    {
        Init();
    }
   

    private void OnEnable()
    {
        openChat = inputPlayer.Player.OpenChat;
        readMessage = inputPlayer.Player.SendMessage;
        moveForward = inputPlayer.Player.MoveForward;
        moveRight = inputPlayer.Player.MoveRight;
        actions.AddRange(new List<InputAction> { openChat, readMessage, moveForward, moveRight });
        
        Active(true);
    }
    private void OnDisable()
    {
        Active(false);
    }


    private void Init()
    {
        inputPlayer = new InputPlayer();
    }
    private void Active(bool active)
    {

        foreach (InputAction action in actions)
        {
            if (active)
                action.Enable();
            else
                action.Disable();
        }
    }
}
