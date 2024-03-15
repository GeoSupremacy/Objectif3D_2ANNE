using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : NetworkBehaviour
{
    public static Action OnOpenChat = null;
    public static Action OnEdit = null;
    [SerializeField] InputComponent inputComponent = null;

    [SerializeField] float speedForward = 3f;
    [SerializeField] float speedRight = 3f;
    void Awake()
    {
        Init();
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(!IsOwner)
        {
            inputComponent.enabled = false;
            transform.position = new Vector3(0, -50, 0);
            return;
        }
       
    }
    public override void OnDestroy()
    {
        OnOpenChat = null;
        OnEdit = null;
    }
    private void Init()
    {
        inputComponent = GetComponent<InputComponent>();
        inputComponent.OpenChat.performed += OpenChat;
        inputComponent.ReadMessage.performed += ReadMessage;
      
    }
    private void Update()
    {
        MoveForward();
        MoveRight();
    }
    private void MoveForward()
    {
        if (!inputComponent)
            return;

        float _axis = inputComponent.MoveForward.ReadValue<float>();

        float _speed = _axis * (speedForward * Time.deltaTime);
        transform.position += transform.forward * _speed;
    }
    private void MoveRight()
    {
        if (!inputComponent)
            return;

        float _axis = inputComponent.MoveForward.ReadValue<float>();

        float _speed = _axis * (speedRight * Time.deltaTime);
        transform.position += transform.forward * _speed;
    }
    void OpenChat(InputAction.CallbackContext _context)
    {
        OnOpenChat?.Invoke();
    }
    void ReadMessage(InputAction.CallbackContext _context)
    {
        
        OnEdit?.Invoke();
    }
}
