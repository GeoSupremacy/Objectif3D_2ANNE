using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using System;

public class ChatSystem : MonoBehaviour
{
    public static Action<string> OnSendMessage = null;
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
        OnSendMessage += UpdateChat;
    }

    private void OnDestroy()
    {
        OnSendMessage = null;
    }
    public void ChatSent(Lobby _lobby, Friend _friend, string _message)
    {
        string msg = _friend.Name + ": " + _message;
     
    }
    private void LobbyEntered(Lobby lobby)=> OnSendMessage?.Invoke("You entered the lobby ");
    private void LobbyMemberLeave(Lobby lobby, Friend friend) => OnSendMessage?.Invoke(friend.Name+" Left the lobby");
    private void LobbyMemberJoined(Lobby lobby, Friend friend) => OnSendMessage?.Invoke(friend.Name + " Joined the lobby");
   
    private void UpdateChat(string _message)
    {
        if (!string.IsNullOrEmpty(_message))
            LobbySaver.Instance.currentLobby?.SendChatString(_message);
    }
}
