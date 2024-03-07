using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LobbySystem : NetworkBehaviour
{
    [SerializeField] Player owner = null;
    [SerializeField] private CustomLobby customLobby = null;
    List<CustomLobby> lobbyList;

    public List<CustomLobby> LobbyList =>LobbyList;
    void Awake()
    {
        owner = GetComponent<Player>();
        owner.OnCreateLobby += Register;
    }
     void Register(string _name, string _playerNumber)
    {
        CustomLobby _newLobby = Instantiate(customLobby);
        _newLobby.Init(_name, _playerNumber);
        LobbyList.Add(_newLobby);
       
    }
   
}
