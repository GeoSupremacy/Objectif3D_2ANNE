using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbySystem : NetworkBehaviour
{
    static public Action<List<SessionLobby>> OnList = null;
    [field:SerializeField] List<SessionLobby> lobbyList = new List<SessionLobby>();

     
    public List<SessionLobby> LobbyList => lobbyList;
    void Awake() => Bind();

    private void Bind()
    {
      
        HUDTitle.OnOpenListLobby += ListServerRpc;
        HUDTitle.OnCreateLobby += Register;
       
    }
    [ServerRpc(RequireOwnership = false)]
    private void ListServerRpc()
    {
        Debug.Log("ListServerRpc");
        ListClientRpc();
    }  

    [ClientRpc]
    void ListClientRpc()
    {
        Debug.Log("ListClientRpc");
        OnList?.Invoke(lobbyList);
    }
    public async static void JoinLobby(string _id)
    {
        await LobbyService.Instance.JoinLobbyByIdAsync(_id);
    }
     void CreateLobby(string _name, int _playerNumber, string _id)
    {
        SessionLobby _lobbyList = new();
        _lobbyList.IdLobby = _id;
        _lobbyList.NameLobby = _name;
        _lobbyList.MaxPlayer = _playerNumber;
        lobbyList.Add(_lobbyList);

        NetworkLogger.Add("New Lobby", Color.yellow);
        NetworkSystem.Shutdown();
    }
    async void Register(string _name, string _playerNumber)
     {
        Debug.Log("Register");
        string lobbyName = _name;
        int maxPlayers = int.Parse(_playerNumber);
       
        CreateLobbyOptions options = new();
      
        options.IsPrivate = false;
       
       
        Lobby lobby =await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
        CreateLobby(lobbyName, maxPlayers, lobby.Id);


     }
    
}
