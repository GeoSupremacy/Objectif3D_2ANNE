using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CustomLobby : MonoBehaviour
{
    
    [SerializeField] TMP_Text nameLobby = null;
    [SerializeField] TMP_Text playerNumber = null;
    [SerializeField] Button joinLobby = null;
    private string id = "id";
    public bool IsValid => nameLobby && playerNumber && joinLobby;


    public void Init(string _nameLobby, string _player, string _id , Action<string> _callback =null)
    {
        if (!IsValid)
        {
            new System.NullReferenceException("CustomLobby: Missing element");
            return;
        }
        joinLobby.onClick.AddListener(() => _callback?.Invoke(id));
        nameLobby.text = _nameLobby;
        playerNumber.text = _player;
        id = _id;
    }
}
