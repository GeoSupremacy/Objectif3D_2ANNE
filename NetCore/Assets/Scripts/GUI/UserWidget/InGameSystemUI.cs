using UnityEngine.UI;

using UnityEngine;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;

public class InGameSystemUI : UserWidget
{
    [SerializeField] private Button disconnectButton;
    [SerializeField] private TMP_Text ownerState;
    [SerializeField] private GameObject inGame;
    List<string> stateOwner = new List<string> { "Server", "Host", "Client", "isDown" };


    public Button DisconnectButton => disconnectButton;
    public GameObject InGame => inGame;
    protected override void Bind()
    {
        disconnectButton.onClick.AddListener(() => { DisConnect(); });
        NetworkSystem.OnStartServer += ChangeStateUI;
        NetworkSystem.OnStartClient += ChangeStateUI;
        NetworkSystem.OnStopClient += ChangeStateUI;
        NetworkSystem.OnStopServer += ChangeStateUI;
    }

    protected override void Init() => ChangeStateUI();
   private void ChangeStateUI()
    {
        
        switch (DataScene.stateOwner)
        {
            case StateOwner.IsServer:
                ownerState.text = stateOwner[0];
                break;
            case StateOwner.IsHost:
                ownerState.text = stateOwner[1];
                break;
            case StateOwner.IsCLient:
                ownerState.text = stateOwner[2];
                break;
            case StateOwner.IsDown:
                ownerState.text = stateOwner[3];
                break;
            default: break;
        }

    }
    void DisConnect()
    {
        DataScene.stateOwner = StateOwner.IsDown;
        NetworkSystem.Shutdown();
        inGame.SetActive(false);

    }
}
