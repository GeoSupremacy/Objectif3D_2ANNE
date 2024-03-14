using Steamworks.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySaver : MonoBehaviour
{
    public Lobby? currentLobby;
    private static LobbySaver instance = null;
    
    public static LobbySaver Instance => instance;  
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
