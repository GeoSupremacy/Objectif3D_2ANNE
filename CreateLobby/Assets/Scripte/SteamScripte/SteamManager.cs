
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using System;
using Unity.Netcode;
using Netcode.Transports.Facepunch;
using UnityEngine.SceneManagement;

public class SteamManager : MonoBehaviour
{

    public static Action<string> OnLobbyId = null;
    private void OnEnable()
    {
        SteamMatchmaking.OnLobbyCreated += LobbyCreated;
        SteamMatchmaking.OnLobbyEntered += LobbyEntered;
        SteamFriends.OnGameLobbyJoinRequested += GameLobbyJoinRequest;
    }

 

    private void OnDisable()
    {
        SteamMatchmaking.OnLobbyCreated -= LobbyCreated;
        SteamMatchmaking.OnLobbyEntered -= LobbyEntered;
        SteamFriends.OnGameLobbyJoinRequested -= GameLobbyJoinRequest;
    }

    private void OnDestroy()
    {
        OnLobbyId = null;
    }
    public async void HostLobby()
    {
        await SteamMatchmaking.CreateLobbyAsync(4); //TODO define maxPlayer
    }

    public async void JoinLobbyWithID(string _id)
    {
        ulong ID;
        if(!ulong.TryParse(_id,out  ID))
            return;
       
        Lobby[] lobbies = await SteamMatchmaking.LobbyList.WithSlotsAvailable(1).RequestAsync(); //TODO min sloat
        foreach(Lobby _lobby in lobbies)
        {
            if (_lobby.Id == ID)
            {
                await _lobby.Join();
                return;
            }
        }
       
    }
    public void CopyId(string _copyId)
    {
        TextEditor _textEditor = new TextEditor();
        _textEditor.text = _copyId;
        _textEditor.SelectAll();
        _textEditor.Copy();
    }
    private void LobbyEntered(Lobby _lobby)
    {
        LobbySaver.Instance.currentLobby = _lobby;
        OnLobbyId?.Invoke(_lobby.Id.ToString()) ;

        NetworkManager.Singleton.gameObject.GetComponent<FacepunchTransport>().targetSteamId = _lobby.Owner.Id;
      
        NetworkManager.Singleton.StartClient();
    }
   
    public void LeaveLobby()
    {
       
        LobbySaver.Instance.currentLobby?.Leave();
        LobbySaver.Instance.currentLobby = null;
        NetworkManager.Singleton.Shutdown();
    }
    
    private  async void GameLobbyJoinRequest(Lobby _lobby, SteamId _id)
    {
        await _lobby.Join();
    }

    private void LobbyCreated(Result _result, Lobby _lobby)
    {
       if(_result ==Result.OK)
        {
            _lobby.SetPublic();
            _lobby.SetJoinable(true);
            NetworkManager.Singleton.StartHost();
        }
    }
    public void StartGameServer()
    {
        if(NetworkManager.Singleton.IsHost)
            NetworkManager.Singleton.SceneManager.LoadScene(SceneNameManager.gameLevel,LoadSceneMode.Single);
    }
}
