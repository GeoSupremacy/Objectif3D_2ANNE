using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputComponent : MonoBehaviour
{
    [SerializeField] InputPlayer inputPlayer = null;
    [SerializeField] InputAction openChat = null;
    [SerializeField] InputAction sendMessage = null;

    [SerializeField] List<InputAction> actions = null;
    public InputAction OpenChat => openChat;
    public new InputAction SendMessage => sendMessage;
    private void Awake()
    {
        Init();
    }
   

    private void OnEnable()
    {
        openChat = inputPlayer.Player.OpenChat;
        sendMessage = inputPlayer.Player.SendMessage;
        actions.AddRange(new List<InputAction> { openChat, sendMessage });
        
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
