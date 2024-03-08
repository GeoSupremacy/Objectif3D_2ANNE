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

    public void UpdateList(List<KeyValuePair<string, string>> _listLobby)
    {
        ClearList();

        for (int i = 0; i < _listLobby.Count; i++)
        {
            KeyValuePair<string, string> lobby = _listLobby[i];
            string _name = lobby.Key;
            string _number = lobby.Value;
            CustomLobby _newLobby = Instantiate(customLobby, lobbyContent);
            _newLobby.Init(_name, _number);
        }
           
    }

    public void ClearList()
    {
        for (int i = 0; lobbyContent && i < lobbyContent.childCount; i++)
            Destroy(lobbyContent.GetChild(i).gameObject);
    }
    void Bind()=> returnButton.onClick.AddListener(() =>{ lobbyUI.SetActive(false);});
    
    private void Start()=>lobbyUI.SetActive(false);
    

 
}
