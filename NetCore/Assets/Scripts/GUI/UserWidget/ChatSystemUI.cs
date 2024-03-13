using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatSystemUI : UserWidget
{
    Action<string> OnSendMessage = null;

    [SerializeField] Player owner = null;
    [SerializeField] TextInChat textInChat = null;
    [SerializeField] TMP_InputField textEnter = null;
    [SerializeField] Transform chatContent = null;

  

    public GameObject ChatSystemUi=> gameUI;
    void SetOwner(Player _this)
    {
        owner = _this;
        OnSendMessage += owner.SendMessage;
        owner.OnReceiveMessage += UpdateMessage;
    }

 
    protected override void Bind()
    {
        Player.Instance += SetOwner;
        textEnter.onEndEdit.AddListener((c) => ReadStringInput(c));
    }

    protected override void Init()
    {
        gameUI.SetActive(false);
    }
   
    private void OnDestroy()
    {
        OnSendMessage = null;
    }
    private void ReadStringInput(string _stringInput)
    {
        
       
        OnSendMessage?.Invoke(_stringInput);
     
    }

    public void UpdateMessage(string _stringInput)
    {
        TextInChat _textInChat = Instantiate(textInChat, chatContent);
        _textInChat.Init(_stringInput);
    }
}
