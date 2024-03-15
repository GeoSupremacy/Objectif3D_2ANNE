using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatLobby : ScripteGUI
{
    public static Action<string> OnSendMessage = null;
    [SerializeField] TMP_Text textInChat = null;
    [SerializeField] Transform content = null;
    
    [SerializeField] TMP_InputField chatEnter = null;

    bool isOpen = false;
    protected override void Bind()
    {
        base.Bind();
     
    }
    protected override void Init()
    {
        if (!textInChat || !content || !chatEnter)
            new System.NullReferenceException("ChatLobby: missing element");
        gameUI.SetActive(false);
        chatEnter.gameObject.SetActive(false);

    }

    private void OnDestroy()
    {
        OnSendMessage = null;
    }
    public void OpenEdit()
    {
       
        if (isOpen)
        { 
            chatEnter.gameObject.SetActive(false);
            isOpen = false;
            return;
        }
        isOpen = true;
        chatEnter.gameObject.SetActive(true);
    }
    public void Send()
    {
        

        if (!isOpen || chatEnter.text == string.Empty)
            return;
      
        OnSendMessage?.Invoke(chatEnter.text); 
    } 
  
    public void UpdateList(string _msg)
    {
        GameObject message = Instantiate(textInChat.gameObject, content.transform);
        message.GetComponent<TMP_Text>().text = _msg;
    }
    public void ClearContent()
    {
        for (int i =0; i < content.childCount; i++) 
            Destroy(content.GetChild(i).gameObject);
        
    }
}
