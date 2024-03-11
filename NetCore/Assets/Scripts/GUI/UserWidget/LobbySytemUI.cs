using System.Collections.Generic;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;

public class LobbySytemUI : MonoBehaviour
{

    [SerializeField] private Button returnButton;
    [SerializeField] private Button joinButton;
    [SerializeField] private GameObject lobbyUI= null;
    [SerializeField] private Transform lobbyContent = null;
    [SerializeField] private CustomLobby customLobby = null;

    [SerializeField] private TMP_InputField findlobby = null;
    string id = "id";
    public Button ReturnButton => returnButton;
    public Button JoinButton => joinButton;
    public GameObject LobbyUI => lobbyUI;
    private void Awake() => Bind();
    private void Start() => lobbyUI.SetActive(false);
 
    private void FindLobbyInput(string _id)
    {
        id = _id;
        NetworkLogger.Add("FindLobby "+ _id, Color.green);
        Debug.Log(id);
    }
    async private void JoinLobby()
    {
        NetworkLogger.Add("JoinLobby", Color.green);
        
        
        await LobbyService.Instance.JoinLobbyByIdAsync(id);
        Return();
    }
    public void UpdateList(List<KeyValuePair<string, string>> _listLobby)
    {
        ClearList();
      //  QueryLobbiesOptions options = new QueryLobbiesOptions();
      //  QueryResponse lobbies = await Lobbies.Instance.QueryLobbiesAsync(options);


          for (int i = 0; i < _listLobby.Count; i++)
          {
              KeyValuePair<string, string> lobby = _listLobby[i];
              string _name = lobby.Key;
              string _number = lobby.Value;
              CustomLobby _newLobby = Instantiate(customLobby, lobbyContent);
              _newLobby.Init(_name, _number);
          }
            
    }
    private void Return()=> lobbyUI.SetActive(false);
    
    public void ClearList()
    {
        for (int i = 0; lobbyContent && i < lobbyContent.childCount; i++)
            Destroy(lobbyContent.GetChild(i).gameObject);
    }
    private void Bind()
    {
      
        findlobby.onEndEdit.AddListener((c) => FindLobbyInput(c));
        returnButton.onClick.AddListener(() => { Return(); }); 
    }
    
    
    

 
}
