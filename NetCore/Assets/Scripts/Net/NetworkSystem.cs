using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NetworkSystem : MonoBehaviour
{
    private bool failClientChecking = false;
    void Awake() => Bind();
    async void Bind()
    {
        await UnityServices.InitializeAsync();
       
        NetworkManager.Singleton.OnTransportFailure += () =>
        {
            NetworkLogger.Add("Fail !", Color.red);
        };
        NetworkManager.Singleton.OnClientConnectedCallback += (c) =>
        {
            NetworkLogger.Add($"{c} -> connected ! ", Color.green);
            RefreshPlayerDatas();
        };
        NetworkManager.Singleton.OnClientDisconnectCallback += (c) =>
        {
            NetworkLogger.Add($"{c} -> disconnected !", Color.red);
        };
        NetworkManager.Singleton.OnServerStarted += () =>
        {
            NetworkLogger.Add($"Server started !", Color.green);
        };
        NetworkManager.Singleton.OnServerStopped += (b) =>
        {
            NetworkLogger.Add($"Server stopped : {b}", Color.red);
        };
        NetworkManager.Singleton.OnClientStarted += () =>
        {
            NetworkLogger.Add($"Client started !", Color.green);
            StartCoroutine(CheckForFail());
        };
        NetworkManager.Singleton.OnClientStopped += (b) =>
        {
            NetworkLogger.Add($"Client stopped : {b}", Color.red);
        };
    
    
    }
    private void Start()
    {
        
        switch (DataScene.stateOwner)
        {
            case StateOwner.IsServer:
                NetworkManager.Singleton.StartServer();
                break;
            case StateOwner.IsHost:
                NetworkManager.Singleton.StartHost();
                break;
            case StateOwner.IsCLient:
                NetworkManager.Singleton.StartClient();
                break;
            case StateOwner.IsDown:
                NetworkManager.Singleton.Shutdown();
                break;
            default:
                break;
        }
    }
    void RefreshPlayerDatas()
    {
        if (NetworkManager.Singleton.IsServer)
            foreach (NetworkClient _c in NetworkManager.Singleton.ConnectedClientsList)
            {
             //   NetworkCustomClient _client = _c.PlayerObject.GetComponent<NetworkCustomClient>();
               // if (_client)
                  //  _client.SendPseudoRpc(_client.name);
            }
    }
    IEnumerator CheckForFail()
    {
        failClientChecking = true;
        yield return new WaitForSeconds(1);
        if (!NetworkManager.Singleton.IsConnectedClient)
            NetworkManager.Singleton.Shutdown();
        failClientChecking = false;
    }
}
