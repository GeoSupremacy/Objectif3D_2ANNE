using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button joinLobbyButton;
    [SerializeField] private Button quitButton;


    [SerializeField] private GameObject mainMenu;

    public GameObject MainMenu => mainMenu;
    private List<Button> buttons;


   public Button ServerButton => serverButton;
   public Button HostButton=>hostButton;
   public Button ClientButton => clientButton;
    public Button CreateLobbyButton => createLobbyButton;
   public Button JoinLobbyButton => joinLobbyButton;
   public Button QuitButton => quitButton;

    private void Awake() => Bind();

    void Bind()
    {
        buttons = new List<Button>() { serverButton, createLobbyButton, hostButton, joinLobbyButton,quitButton, clientButton };


        serverButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
            NetworkManager.Singleton.StartServer();
            DataScene.stateOwner = StateOwner.IsServer;
        });
        hostButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
            NetworkManager.Singleton.StartHost();
            DataScene.stateOwner = StateOwner.IsHost;
        });
        clientButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);

            NetworkManager.Singleton.StartClient();
            DataScene.stateOwner = StateOwner.IsCLient;
        });

        createLobbyButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);

        });
        joinLobbyButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
         
       

        });

        quitButton.onClick.AddListener(() =>
        {
            Active(null);
          
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        });
    }
    private void Start()
    {
        if (!checkButton())
            new System.NullReferenceException("Missing button");

     
    }
    private void OnDestroy()
    {
        
    }
    bool checkButton()
    {
        foreach (Button _button in buttons)
            if (!_button) return false;
        return true;
    }
    void Active(Button _button)
    {
        foreach (Button button in buttons)
            if (button == _button) button.gameObject.SetActive(true);
            else button.gameObject.SetActive(false);
    }
}
