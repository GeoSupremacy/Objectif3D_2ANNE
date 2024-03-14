using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InLobbyMenuGUI : ScripteGUI
{
    public static Action<string> OnCopyID = null;

    [SerializeField] Button enterGameButton = null;
    [SerializeField] Button copyIDButton = null;
    [SerializeField] Button leaveLobbyButton = null;
    [SerializeField] TMP_Text textID = null;
    public GameObject InLobbyMenuUI => gameUI;
    public Button EnterGameButton => enterGameButton;
    public Button CopyIDButton => copyIDButton;
    public Button LeaveLobbyButton => leaveLobbyButton;

    private void OnDestroy()
    {
        OnCopyID = null;
}
    protected override void Bind()
    {
        enterGameButton.onClick.AddListener(EnterGame);
        copyIDButton.onClick.AddListener(CopyID);
        leaveLobbyButton.onClick.AddListener(LeaveLobby);
    }

    protected override void Init()
    {
        if (!enterGameButton || !copyIDButton || !leaveLobbyButton || !textID)
            new System.NullReferenceException("ChatLobby: missing element");
        
        gameUI.SetActive(false);
    }
    void EnterGame()
    {
       
    }
    void CopyID()
    {
        OnCopyID?.Invoke(textID.text);
    }
    void LeaveLobby()
    {
       if(LobbySaver.Instance.currentLobby != null)
            gameUI.SetActive(false);
       else gameUI.SetActive(true);
    }
    public void SetID(string _id)
    {
        //Recup lobby ID
        textID.text = _id;
    }
}
