using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChatSystem : NetworkBehaviour
{
    public static Action<string> OnReceiveMessage = null;
    [SerializeField] Player owner = null;

    

    private void Awake()
    {
        owner = GetComponent<Player>();
        owner.OnSendMessage += SendMessageServerRpc;
    }


    [ServerRpc(RequireOwnership = false)]
    private void SendMessageServerRpc(string _stringMessage)
    {
       
        SendMessageClientRpc(_stringMessage);
    }

    [ClientRpc(RequireOwnership =true)]
    private void SendMessageClientRpc(string _stringMessage)
    {
       
        OnReceiveMessage?.Invoke(_stringMessage);
        
    }
}
