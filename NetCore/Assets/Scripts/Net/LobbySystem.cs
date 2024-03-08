using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LobbySystem : NetworkBehaviour
{
    Action<List<KeyValuePair<string, string>>> OnList = null;
   [field:SerializeField] List<KeyValuePair<string, string>> lobbyList = new List<KeyValuePair<string, string>>();

    public List<KeyValuePair<string, string>> LobbyList => lobbyList;
    void Awake() => Bind();

   
     
    void Bind()
    {
        HUD.OnOpenListLobby += ListServerRpc;
        HUD.OnCreateLobby += Register;

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
    void Register(string _name, string _playerNumber)
     {

        KeyValuePair<string, string> _lobbyList = new KeyValuePair<string, string> ( _name, _playerNumber );
        lobbyList.Add( _lobbyList );

        NetworkManager.Singleton.StartHost();
     }
    
}
