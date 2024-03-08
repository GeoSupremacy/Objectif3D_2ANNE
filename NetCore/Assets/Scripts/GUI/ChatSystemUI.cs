using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystemUI : MonoBehaviour
{
    Action<string> OnSendMessage = null;

    [SerializeField] Player owner = null;
    [SerializeField] TextInChat textInChat = null;
    [SerializeField] Transform chatContent = null;

    [SerializeField] private GameObject chatSystemUI;

    public GameObject ChatSystemUi=> chatSystemUI;
    void SetOwner(Player _this)
    {
        owner = _this;
        OnSendMessage += owner.SendMessage;
        owner.OnReceiveMessage += UpdateMessage;
    }

    private void Awake()
    {
        Player.Instance += SetOwner;
    }
    private void Start()
    {
        chatSystemUI.SetActive(false);
    }
    private void OnDestroy()
    {
        OnSendMessage = null;
    }
    public void ReadStringInput(string _stringInput)
    {
        
       
        OnSendMessage?.Invoke(_stringInput);
     
    }

    public void UpdateMessage(string _stringInput)
    {
        TextInChat _textInChat = Instantiate(textInChat, chatContent);
        _textInChat.Init(_stringInput);
    }
}
