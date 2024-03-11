using UnityEngine.UI;

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class InGameSystemUI : MonoBehaviour
{
    [SerializeField] private Button disconnectButton;
    [SerializeField] private TMP_Text ownerState;
    public Button DisconnectButton => disconnectButton;
    List<string> stateOwner = new List<string>{"Server","Host","Client" };
    private void Awake() => Bind();
    private void Bind()
    {
        disconnectButton.onClick.AddListener(() => { DisConnect(); });
    }

    private void Start()
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
            default: break;
        }
            
    }
    void DisConnect()
    {
       
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
}
