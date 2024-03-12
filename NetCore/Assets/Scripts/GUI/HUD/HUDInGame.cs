using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDInGame : HUD
{

    [SerializeField] private MenuUI menu;
    [SerializeField] private InGameSystemUI inGame;
    [SerializeField] private ChatSystemUI chat;

    protected override void Bind()
    {
        if (!menu || !chat || !inGame)
            new System.NullReferenceException("HUD missing UI");

        //DisconnectButton => load
        //SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}