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
        OnList?.Invoke(lobbyList);
    }
    public async static void JoinLobby(string _id)
    {
        await LobbyService.Instance.JoinLobbyByIdAsync(_id);
    }
    async void Register(string _name, string _playerNumber)
     {
       
        string lobbyName = _name;
        int maxPlayers = int.Parse(_playerNumber);
       
        CreateLobbyOptions options = new();
      
        options.IsPrivate = false;
       
       
        Lobby lobby =await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

        SessionLobby _lobbyList = new();
        _lobbyList.IdLobby = lobby.Id;
        _lobbyList.NameLobby = lobbyName;
        _lobbyList.MaxPlayer = maxPlayers;
        lobbyList.Add( _lobbyList );
       
        NetworkLogger.Add("New Lobby", Color.yellow);
        NetworkSystem.Shutdown();
     }
    
}
