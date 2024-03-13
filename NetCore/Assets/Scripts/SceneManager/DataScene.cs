using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public enum StateOwner
{
    IsServer,
    IsHost,
    IsCLient,
    IsDown,
    IsState,
}
public class DataScene
{
    public const string gameLevel = "Game";
    public const string mainLevel = "MainMenuScene";
    public static StateOwner stateOwner = StateOwner.IsState;
    public static bool isCreateLobby = false;
}
