using System;
using System.Collections;
using Unity.Netcode;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;
public class NetworkSystem : NetworkBehaviour
{
    public static Action OnStartServer = null;
    public static Action OnStartClient = null;
    public static Action OnStopServer = null;
    public static Action OnStopClient = null;
    private bool failClientChecking = false;
    private bool isHost = false;
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
            OnStopClient?.Invoke();
        };
        NetworkManager.Singleton.OnServerStarted += () =>
        {
            NetworkLogger.Add($"Server started !", Color.green);
            DataScene.stateOwner = StateOwner.IsServer;
            OnStartServer?.Invoke();
            isHost = true;
        };
        NetworkManager.Singleton.OnServerStopped += (b) =>
        {
            NetworkLogger.Add($"Server stopped : {b}", Color.red);
            DataScene.stateOwner = StateOwner.IsDown;
            OnStopServer?.Invoke();
        };
        NetworkManager.Singleton.OnClientStarted += () =>
        {
            NetworkLogger.Add($"Client started !", Color.green);
            if(isHost)
            { 
                isHost = false;
                DataScene.stateOwner = StateOwner.IsHost;
            }
            else
                DataScene.stateOwner = StateOwner.IsCLient;
            

            OnStartClient?.Invoke();
            StartCoroutine(CheckForFail());
        };
        NetworkManager.Singleton.OnClientStopped += (b) =>
        {
            
            DataScene.stateOwner = StateOwner.IsDown;
            NetworkLogger.Add($"Client stopped : {b}", Color.red);
        };

      
    }
    private void Start()
    {
        //When Game start or change level
        StateManager();
    }
    public  static void StateManager()
    {
        
        if(DataScene.isCreateLobby)
            DataScene.stateOwner= StateOwner.IsHost;
          
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
    public  override void OnDestroy()
    {
        OnStartServer = null;
        OnStartClient = null;
        OnStopServer = null;
        OnStopClient = null;
    }
    public static void StartServer() => NetworkManager.Singleton.StartServer();
    public static void StartHost() => NetworkManager.Singleton.StartHost();
    public static void StartClient() => NetworkManager.Singleton.StartClient();
    public static void Shutdown()
    {
        
        NetworkManager.Singleton.Shutdown();
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

    static public void LoadScene(string _name)
    {
        SceneEventProgressStatus status = NetworkManager.Singleton.SceneManager.LoadScene(_name, LoadSceneMode.Single);
        if (status != SceneEventProgressStatus.Started)
        {
            NetworkLogger.Add($"Failed to load {_name} " +
                  $"with a {nameof(SceneEventProgressStatus)}: {status}", Color.red);
        }
    }
}
