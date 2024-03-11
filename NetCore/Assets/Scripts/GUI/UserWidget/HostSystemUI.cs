using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HostSystemUI : MonoBehaviour
{
    public Action<string, string> OnCreateLobby { get; set; } = null;

    [SerializeField] Player owner = null;

    [SerializeField] private Button createButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject hostUI;


    [SerializeField] private TMP_InputField readName;
    [SerializeField] private TMP_InputField readMaxPlayer;
    string playerNumber;
    string lobbyName;
    public GameObject HostUI => hostUI;
    public Button CreateButton => createButton;
    public Button ReturnButton => returnButton;

    void SetOwner(Player _this)
    {
        owner = _this;
    }

   
    private void Awake()
    {
        Player.Instance += SetOwner;
        createButton.onClick.AddListener(() => CreateLobby());
        returnButton.onClick.AddListener(() => Return());
        readName.onEndEdit.AddListener((c) => ReadNameLobbyInput(c));
        readMaxPlayer.onEndEdit.AddListener((c) => ReadPlayerNumberInput(c));
    }

    private void Start()
    {
        hostUI.SetActive(false);
    }
    private void ReadNameLobbyInput(string _stringInput)
    {
      
        lobbyName = _stringInput;
        NetworkLogger.Add("Name Lobby " + lobbyName, Color.green);
    }

    private void ReadPlayerNumberInput(string _stringInput)
    {
       
        playerNumber = _stringInput;
        NetworkLogger.Add("NumerP " + playerNumber, Color.green);
    }

    private void CreateLobby()
    {
       
       
        OnCreateLobby?.Invoke(lobbyName, playerNumber);
        hostUI.SetActive(false);
    }

    private void Return()
    {
       
        hostUI.SetActive(false);
    }
}
