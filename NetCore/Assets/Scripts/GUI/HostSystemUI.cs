using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HostSystemUI : MonoBehaviour
{
    public Action<string, string> OnCreateLobby { get; set; } = null;
    [SerializeField] private Button createButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject hostUI;

    string playerNumber;
    string lobbyName;
    public GameObject HostUI => hostUI;
    public Button CreateButton => createButton;
    public Button ReturnButton => returnButton;

 
    private void Awake()
    {
        createButton.onClick.AddListener(() => CreateLobby());
        returnButton.onClick.AddListener(() => Return());
    }

    private void Start()
    {
        hostUI.SetActive(false);
    }
    public void ReadNameLobbyInput(string _stringInput)
    {

        lobbyName = _stringInput;

    }

    public void ReadPlayerNumberInput(string _stringInput)
    {
        playerNumber = _stringInput;
    }

    void CreateLobby()
    {
        OnCreateLobby?.Invoke(lobbyName, playerNumber);
    }

    void Return()
    {
        hostUI.SetActive(false);
    }
}
