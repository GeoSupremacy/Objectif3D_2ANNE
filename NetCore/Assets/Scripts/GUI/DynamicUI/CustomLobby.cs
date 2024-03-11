using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomLobby : MonoBehaviour
{
    
    [SerializeField] TMP_Text nameLobby = null;
    [SerializeField] TMP_Text playerNumber = null;
    public bool IsValid => nameLobby && playerNumber;


    public void Init(string _nameLobby, string _player)
    {
        if (!IsValid)
        {
            new System.NullReferenceException("CustomLobby: Missing element");
            return;
        }

        nameLobby.text = _nameLobby;
        playerNumber.text = _player;
    }
}
