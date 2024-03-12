using System;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    
    public static Action<string, string> OnCreateLobby { get; set; } = null;
    public static Action<Player> Instance;
    public Action<string> OnSendMessage{ get; set; } = null;
    public Action<string> OnReceiveMessage { get; set; } = null;

    [SerializeField] InputComponent inputs = null;
    public InputComponent Inptus => inputs;
    float speedForward = 3.0f;

   
    void Start()=>  Init();

    private void Update() => Move();

  
    public void ReceiveMessage(string _stringMessage)
    {
        if (!IsOwner)
            return;
     
        OnReceiveMessage?.Invoke(_stringMessage);
    }
    public new void SendMessage(string _stringMessage)
    {
        if (!IsOwner)
            return;
        OnSendMessage?.Invoke(OwnerClientId+ " : "+_stringMessage); 
    }
    void Init()
    {
        inputs = GetComponent<InputComponent>();
        ChatSystem.OnReceiveMessage += ReceiveMessage;
    }
    void Move()=>MoveForward();
    void MoveForward()
    {
        if (!inputs)
            return;

        float _axis = inputs.MoveForward.ReadValue<float>();

        float _speed = _axis * (speedForward * Time.deltaTime);
        transform.position += transform.forward * _speed;

    }
}
