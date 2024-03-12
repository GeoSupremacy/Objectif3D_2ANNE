using System;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine;
using System.Xml.Linq;

public class HUDTitle : HUD
{
    public static Action<string, string> OnCreateLobby { get; set; } = null;
    public static Action OnOpenListLobby { get; set; } = null;
    [SerializeField] private MainMenuUI mainMenu;
    [SerializeField] private LobbyMenu lobbyMenu;
    [SerializeField] private LobbySytemUI lobby;
    [SerializeField] private HostSystemUI host;
    [SerializeField] private InGameSystemUI inGame;
    protected override void Bind() 
    {
        if (!mainMenu || !lobby || !host || !inGame || !lobbyMenu)
            new System.NullReferenceException("HUD missing UI");

        lobbyMenu.CreateLobbyButton.onClick.AddListener(() => OpenLobby());
        lobbyMenu.JoinLobbyButton.onClick.AddListener(() => OpenListLobby());
        


        mainMenu.ServerButton.onClick.AddListener(() => EnterInSession());
        mainMenu.HostButton.onClick.AddListener(() => EnterInSession());
        mainMenu.ClientButton.onClick.AddListener(() => EnterInSession());


        lobby.ReturnButton.onClick.AddListener(() => OpenMainMenu());
        host.ReturnButton.onClick.AddListener(() => OpenMainMenu());

        host.OnCreateLobby += CreateLobby;
       
        inGame.DisconnectButton.onClick.AddListener(() => OpenMainMenu()); 
    }

    private void Start()
    {
        if(inGame)
            inGame.InGame.SetActive(false);
    }
    void CreateLobby(string _name, string _number)
    {
        OnCreateLobby?.Invoke(_name, _number);
        DataScene.isCreateLobby = true;
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
    void EnterInSession()
    {
      

        inGame.InGame.SetActive(true);
        lobbyMenu.MainLobby.SetActive(true);
    
    }
    void EnterInGame()
    {
      
       SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    void OpenMainMenu()
    {
        lobbyMenu.MainLobby.SetActive(false);
        mainMenu.MainMenu.SetActive(true);
    }
}
