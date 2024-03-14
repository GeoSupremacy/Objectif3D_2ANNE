using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGUI : ScripteGUI
{
    public static Action<string> OnEditId = null;

    [SerializeField] Button startHostButton = null;
    [SerializeField] Button joinLobbyButton= null;
    [SerializeField] TMP_InputField inputFieldLobbyID = null;
 
    public GameObject MainMenuUI => gameUI;
    public Button StartHostButton => startHostButton;
    public Button JoinLobbyButton => joinLobbyButton;

    private void OnDestroy()
    {
        OnEditId = null;
    }
    protected override void Bind()
    {
        inputFieldLobbyID.onEndEdit.AddListener( EditID);
        startHostButton.onClick.AddListener(StartHost);
        joinLobbyButton.onClick.AddListener(JoinLobby);
    }
    protected override void Init()
    {
        if (!startHostButton || !joinLobbyButton || !inputFieldLobbyID)
            new System.NullReferenceException("ChatLobby: missing element");
    }

    void StartHost()
    {
        gameUI.SetActive(false);
    }
    void JoinLobby()
    {
       gameUI.SetActive(false);
    }
    void EditID(string _id)
    {
        OnEditId?.Invoke( _id );
    }

  
}
