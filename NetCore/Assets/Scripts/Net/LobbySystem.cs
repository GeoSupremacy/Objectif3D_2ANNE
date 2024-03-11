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
    Action<List<KeyValuePair<string, string>>> OnList = null;
   [field:SerializeField] List<KeyValuePair<string, string>> lobbyList = new List<KeyValuePair<string, string>>();

    public List<KeyValuePair<string, string>> LobbyList => lobbyList;
    void Awake() => Bind();

    private static string id;
    public static string ID => id;    
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
    async void Register(string _name, string _playerNumber)
     {
       
        string lobbyName = _name;
        int maxPlayers = int.Parse(_playerNumber);
       
        CreateLobbyOptions options = new();
      
        options.IsPrivate = false;
       
       
        Lobby lobby =await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
       
        KeyValuePair<string, string> _lobbyList = new KeyValuePair<string, string> ( _name, _playerNumber );
        lobbyList.Add( _lobbyList );
        id = lobby.Id;
        NetworkLogger.Add("New Lobby", Color.yellow);
        NetworkManager.Singleton.Shutdown();
        NetworkManager.Singleton.StartHost();
     }
    
}
