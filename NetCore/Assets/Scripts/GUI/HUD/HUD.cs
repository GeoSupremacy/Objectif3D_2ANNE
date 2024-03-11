using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    /*
   public static Action<string, string> OnCreateLobby { get; set; } = null;
    public static Action OnOpenListLobby { get; set; } = null;
    [SerializeField] private MainMenuUI mainMenu;
    [SerializeField] private LobbySytemUI lobby;
    [SerializeField] private ChatSystemUI chat;
    [SerializeField] private HostSystemUI host;
    */

    private void Awake() => Bind();
   

   protected virtual void Bind()
    {
        /*
        if (!mainMenu || !lobby || !host)
            new System.NullReferenceException("HUD missing UI");

        mainMenu.CreateLobbyButton.onClick.AddListener(() => OpenLobby());

        mainMenu.ServerButton.onClick.AddListener(()=>EnterInGame()); 
        mainMenu.HostButton.onClick.AddListener(() => EnterInGame());
        mainMenu.ClientButton.onClick.AddListener(() => EnterInGame());

        mainMenu.JoinLobbyButton.onClick.AddListener(() =>OpenListLobby());
        
        lobby.ReturnButton.onClick.AddListener(() => OpenMainMenu());
        lobby.JoinButton.onClick.AddListener(() => EnterInGame());


        host.ReturnButton.onClick.AddListener(() => OpenMainMenu());

        host.OnCreateLobby += CreateLobby;
        */
    }
    /*
    void CreateLobby(string _name, string _number)
    {
       // OnCreateLobby?.Invoke(_name, _number);
        EnterInGame();
    }
    void OpenLobby()
    {
        
        host.HostUI.SetActive(true);

    }
    void OpenListLobby()
    {
       // OnOpenListLobby?.Invoke();
        lobby.LobbyUI.SetActive(true);
    }
    void EnterInGame()
    {
        chat.ChatSystemUi.SetActive(true);
    }
    void OpenMainMenu()
    {
        mainMenu.MainMenu.SetActive(true);
    }

    */
}
