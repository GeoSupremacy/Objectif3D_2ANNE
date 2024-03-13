using System;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;

public class LobbySytemUI : UserWidget
{
    public static Action<string> OnJoin = null;
    [SerializeField] private Button returnButton;
    [SerializeField] private Transform lobbyContent = null;
    [SerializeField] private CustomLobby customLobby = null;

    public Button ReturnButton => returnButton;
    public GameObject LobbyUI => gameUI;

    protected override void Bind()
    {
        LobbySystem.OnList += UpdateList;
        OnJoin += LobbySystem.JoinLobby;
        returnButton.onClick.AddListener(() => { Return(); });
    }
    protected override void Init()
    {
        gameUI.SetActive(false);
    }

    public void UpdateList(List<SessionLobby> _listLobby)
    {
        Debug.Log("UpdateList");
        ClearList();
      //  QueryLobbiesOptions options = new QueryLobbiesOptions();
      //  QueryRes ponse lobbies = await Lobbies.Instance.QueryLobbiesAsync(options);


          for (int i = 0; i < _listLobby.Count; i++)
          {
              SessionLobby lobby = _listLobby[i];
              string _name = lobby.NameLobby;
              string _number = lobby.MaxPlayer.ToString();
              string _id = lobby.IdLobby;
              CustomLobby _newLobby = Instantiate(customLobby, lobbyContent);
              _newLobby.Init(_name, _number, _id, OnJoin);
          }
            
    }
    private void Return()=> gameUI.SetActive(false);
    
    public void ClearList()
    {
        for (int i = 0; lobbyContent && i < lobbyContent.childCount; i++)
            Destroy(lobbyContent.GetChild(i).gameObject);
    }
    
    
    
    

 
}
