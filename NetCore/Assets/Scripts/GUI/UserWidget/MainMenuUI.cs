using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UserWidget
{

    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private GameObject mainMenu;

    public GameObject MainMenu => mainMenu;
    private List<Button> buttons;


   public Button ServerButton => serverButton;
   public Button HostButton=>hostButton;
   public Button ClientButton => clientButton;
   public Button QuitButton => quitButton;

    protected override void Bind() 
    {
        buttons = new List<Button>() { serverButton, hostButton, clientButton, quitButton };


        serverButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
            NetworkSystem.StartServer();
        });
        hostButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
            NetworkSystem.StartHost();
        });
        clientButton.onClick.AddListener(() =>
        {
            mainMenu.gameObject.SetActive(false);
            NetworkSystem.StartClient();
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
  
    protected override void Init()
    {
        if (!checkButton())
            new System.NullReferenceException("Missing button");

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
