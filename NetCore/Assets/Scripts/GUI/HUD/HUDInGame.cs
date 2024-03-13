using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class HUDInGame : HUD
{

    [SerializeField] private MenuUI menu;
    [SerializeField] private InGameSystemUI inGame;
    [SerializeField] private ChatSystemUI chat;

    protected override void Bind()
    {
        if (!menu || !chat || !inGame)
            new System.NullReferenceException("HUD missing UI");
        inGame.DisconnectButton.onClick.AddListener(() => ReturnMainMenu());
      
    }
    void ReturnMainMenu()
    {
        NetworkSystem.Shutdown();
        NetworkSystem.LoadScene(DataScene.mainLevel);
    }
}