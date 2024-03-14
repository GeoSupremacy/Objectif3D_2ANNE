using Steamworks.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHUDManager : HUD
{
    public static Action<string> OnEditId = null;
    public static Action OnLeave = null;

    [SerializeField] MainMenuGUI mainMenu = null;
    [SerializeField] InLobbyMenuGUI lobbyMenu = null;
    [SerializeField] ChatLobby chat = null;
    [SerializeField] SteamManager steamManager = null;

    private void OnDestroy()
    {
        OnEditId = null;
        OnLeave = null;
    }
    protected override void Bind()
    {

        Player.OnOpenChat += chat.OpenEdit;
        Player.OnEdit += chat.Send;
        MainMenuGUI.OnEditId += EditID;
        SteamManager.OnLobbyId += lobbyMenu.SetID;
        ChatSystem.OnSendMessage += chat.UpdateList;
        InLobbyMenuGUI.OnCopyID += steamManager.CopyId;

        OnEditId += steamManager.JoinLobbyWithID;
        OnLeave += steamManager.LeaveLobby;
        OnLeave += chat.ClearContent;

        mainMenu.StartHostButton.onClick.AddListener(CreateHost);
        mainMenu.JoinLobbyButton.onClick.AddListener(JoinLobby);

        lobbyMenu.LeaveLobbyButton.onClick.AddListener(Leave);
    }

   

    protected override void Init()
    {
        if (!mainMenu || !lobbyMenu || !steamManager || !chat)
            new System.NullReferenceException("MainMenuHUDManager: missing element");
    }

    void EditID(string _id)
    {
        OnEditId?.Invoke(_id);
    }
    void CreateHost()
    {
        steamManager.HostLobby();
        mainMenu.MainMenuUI.SetActive(false);
        chat.GameUI.SetActive(true);
        lobbyMenu.InLobbyMenuUI.SetActive(true);
    }
    private void JoinLobby()
    {
        
        mainMenu.MainMenuUI.SetActive(false);
        lobbyMenu.InLobbyMenuUI.SetActive(true);
    }

    private void Leave()
    {
        if (LobbySaver.Instance.currentLobby == null)
            mainMenu.MainMenuUI.SetActive(false);
        else mainMenu.MainMenuUI.SetActive(true);
        OnLeave?.Invoke();
    }
}
