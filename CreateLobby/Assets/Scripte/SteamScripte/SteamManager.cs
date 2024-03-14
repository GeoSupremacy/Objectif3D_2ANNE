
using UnityEngine;
using Steamworks;
using Steamworks.Data;
using System;



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
        NetworkLogger.Add("Entered", UnityEngine.Color.green);
    }
   
    public void LeaveLobby()
    {
        NetworkLogger.Add("LeaveLobby", UnityEngine.Color.green);
        LobbySaver.Instance.currentLobby?.Leave();
       
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
        }
    }

}
