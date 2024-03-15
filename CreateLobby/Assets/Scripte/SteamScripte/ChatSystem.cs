using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using System;

public class ChatSystem : MonoBehaviour
{
    public static Action<string> OnSendMessageInChat = null;
    public static Action<string> OnClearMessage = null;
    private void OnEnable()
    {
        SteamMatchmaking.OnChatMessage += ChatSent;
        SteamMatchmaking.OnLobbyEntered += LobbyEntered;
        SteamMatchmaking.OnLobbyMemberJoined += LobbyMemberJoined;
        SteamMatchmaking.OnLobbyMemberLeave += LobbyMemberLeave;
    }

    private void Awake()
    {
      
        ChatLobby.OnSendMessage += ReadMessage;
    }

    private void OnDestroy()
    {
        OnSendMessageInChat = null;
    }
    public void ChatSent(Lobby _lobby, Friend _friend, string _message)
    {
        string msg = _friend.Name + ": " + _message;
       
        OnSendMessageInChat?.Invoke(msg);

    }
    public  void ReadMessage(string _msg) 
    {
        if (!string.IsNullOrEmpty(_msg))
            LobbySaver.Instance.currentLobby?.SendChatString(_msg);
        
       
    }
    private void LobbyEntered(Lobby lobby) => OnSendMessageInChat?.Invoke("You entered the lobby ");
    private void LobbyMemberLeave(Lobby lobby, Friend friend) => OnSendMessageInChat?.Invoke(friend.Name+" Left the lobby");
    private void LobbyMemberJoined(Lobby lobby, Friend friend) => OnSendMessageInChat?.Invoke(friend.Name + " Joined the lobby");
   

}
