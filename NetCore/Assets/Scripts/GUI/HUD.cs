using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

//   NetworkManager.Singleton.Shutdown();
public class HUD : MonoBehaviour
{
    public Action<string, string> OnCreateLobby { get; set; } = null;
    [SerializeField] private MainMenuUI mainMenu;
    [SerializeField] private LobbySytemUI lobby;
    [SerializeField] private ChatSystemUI chat;
    [SerializeField] private HostSystemUI host;

    
    private void Awake() => Bind();

  
    void Bind()
    {
        if (!mainMenu || !lobby || !host)
            new System.NullReferenceException("HUD missing UI");

        mainMenu.HostButton.onClick.AddListener(() => OpenLobby());
      
        mainMenu.JoinLobbyButton.onClick.AddListener(() =>OpenListLobby());
        
        lobby.ReturnButton.onClick.AddListener(() => OpenMainMenu());

        host.ReturnButton.onClick.AddListener(() => OpenMainMenu());

        host.OnCreateLobby += CreateLobby;
        host.OnCreateLobby += lobby.UpdateList;
    }
    void CreateLobby(string _name, string _number)
    {
        OnCreateLobby?.Invoke(_name, _number);
    }
    void OpenLobby()
    {

        host.HostUI.SetActive(true);
    }
    void OpenListLobby()
    {

        lobby.LobbyUI.SetActive(true);
    }
    
    void OpenMainMenu(){ mainMenu.MainMenu.SetActive(true);}

  
}
