using System;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine;

public class HUDTitle : HUD
{
    public static Action<string, string> OnCreateLobby { get; set; } = null;
    public static Action OnOpenListLobby { get; set; } = null;
    [SerializeField] private MainMenuUI mainMenu;
    [SerializeField] private LobbySytemUI lobby;
    [SerializeField] private HostSystemUI host;

    protected override void Bind() 
    {
        if (!mainMenu || !lobby || !host)
            new System.NullReferenceException("HUD missing UI");

        mainMenu.CreateLobbyButton.onClick.AddListener(() => OpenLobby());
        mainMenu.JoinLobbyButton.onClick.AddListener(() => OpenListLobby());

        mainMenu.ServerButton.onClick.AddListener(() => EnterInGame());
        mainMenu.HostButton.onClick.AddListener(() => EnterInGame());
        mainMenu.ClientButton.onClick.AddListener(() => EnterInGame());


        lobby.ReturnButton.onClick.AddListener(() => OpenMainMenu());
        lobby.JoinButton.onClick.AddListener(() => EnterInGame());
        host.ReturnButton.onClick.AddListener(() => OpenMainMenu());

        host.OnCreateLobby += CreateLobby;
    }

    void CreateLobby(string _name, string _number)
    {
        OnCreateLobby?.Invoke(_name, _number);
        EnterInGame();
    }
    void OpenLobby()
    {

        host.HostUI.SetActive(true);

    }
    void OpenListLobby()
    {
        OnOpenListLobby?.Invoke();
        lobby.LobbyUI.SetActive(true);
    }
    void EnterInGame()
    {
       NetworkManager.Singleton.Shutdown();
       SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    void OpenMainMenu()
    {
        mainMenu.MainMenu.SetActive(true);
    }
}
