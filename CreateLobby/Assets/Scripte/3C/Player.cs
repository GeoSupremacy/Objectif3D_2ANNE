using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Action OnOpenChat = null;
    public static Action OnEdit = null;
    [SerializeField] InputComponent inputComponent = null;
    
    
    void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        OnOpenChat = null;
    }
    private void Init()
    {
        inputComponent = GetComponent<InputComponent>();
        inputComponent.OpenChat.performed += OpenChat;
        inputComponent.SendMessage.performed += SendMessage;
    }

    void OpenChat(InputAction.CallbackContext _context)
    {
        OnOpenChat?.Invoke();
    }
    void SendMessage(InputAction.CallbackContext _context)
    {
        OnEdit?.Invoke();
    }
}
