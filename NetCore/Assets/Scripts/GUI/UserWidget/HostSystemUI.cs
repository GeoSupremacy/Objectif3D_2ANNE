using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HostSystemUI : UserWidget
{
    public Action<string, string> OnCreateLobby { get; set; } = null;

    [SerializeField] Player owner = null;

    [SerializeField] private Button createButton;
    [SerializeField] private Button returnButton;


    [SerializeField] private TMP_InputField readName;
    [SerializeField] private TMP_InputField readMaxPlayer;
    string playerNumber;
    string lobbyName;
    public GameObject HostUI => gameUI;
    public Button CreateButton => createButton;
    public Button ReturnButton => returnButton;

    void SetOwner(Player _this)
    {
        owner = _this;
    }

    protected override void Bind()
    {
        Player.Instance += SetOwner;
        createButton.onClick.AddListener(() => CreateLobby());
        returnButton.onClick.AddListener(() => Return());
        readName.onEndEdit.AddListener((c) => WriteNameLobbyInput(c));
        readMaxPlayer.onEndEdit.AddListener((c) => WritePlayerNumberInput(c));
    }
    protected override void Init()
    {
        gameUI.SetActive(false);
    }
    
    private void WriteNameLobbyInput(string _stringInput)
    {
      
        lobbyName = _stringInput;
    }

    private void WritePlayerNumberInput(string _stringInput)
    {
       
        playerNumber = _stringInput;
    }

    private void CreateLobby()
    {

        Debug.Log("CreateLobby");
        OnCreateLobby?.Invoke(lobbyName, playerNumber);
        gameUI.SetActive(false);
    }

    private void Return()
    {

        gameUI.SetActive(false);
    }
}
