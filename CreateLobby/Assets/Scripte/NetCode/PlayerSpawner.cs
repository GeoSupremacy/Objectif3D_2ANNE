using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject player = null;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    public override void OnNetworkSpawn()
    {
        NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneLoaded;
    }

    private void SceneLoaded(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
       if(IsHost && sceneName == SceneNameManager.gameLevel)
        {
            foreach(ulong client in clientsCompleted) 
            {
                GameObject _player = Instantiate(player);
                _player.GetComponent<NetworkObject>().SpawnAsPlayerObject(client, true);
            }
        }
    }
}
