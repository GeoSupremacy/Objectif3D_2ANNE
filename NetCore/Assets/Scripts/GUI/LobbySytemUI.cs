using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class LobbySytemUI : MonoBehaviour
{

    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject lobbyUI= null;
    [SerializeField] private Transform lobbyContent = null;
    [SerializeField] private CustomLobby customLobby = null;
    public Button ReturnButton => returnButton;
    public GameObject LobbyUI => lobbyUI;
    private void Awake() => Bind();

    public void UpdateList(string _name, string _number)
    {
        CustomLobby _newLobby = Instantiate(customLobby, lobbyContent);
        _newLobby.Init(_name, _number);
    }
    void Bind()=> returnButton.onClick.AddListener(() =>{ lobbyUI.SetActive(false);});
    
    private void Start()
    {
        lobbyUI.SetActive(false);
    }

 
}
