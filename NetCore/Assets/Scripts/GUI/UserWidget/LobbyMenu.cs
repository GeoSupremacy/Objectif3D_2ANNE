using UnityEngine.UI;
using UnityEngine;

public class LobbyMenu : UserWidget
{
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button joinLobbyButton;


    public bool IsValid => createLobbyButton && joinLobbyButton;
    public Button CreateLobbyButton => createLobbyButton;
    public Button JoinLobbyButton => joinLobbyButton;
  

    public GameObject MainLobby => gameUI;
    protected override void Bind()
    {
        createLobbyButton.onClick.AddListener(() =>
        {
            gameUI.gameObject.SetActive(false);

        });
        joinLobbyButton.onClick.AddListener(() =>
        {
            gameUI.gameObject.SetActive(false);



        });
        NetworkSystem.OnStartServer += UpdateUI;
        NetworkSystem.OnStartClient += UpdateUI;
    }
    private void UpdateUI()
    {
        if (!IsValid)
            return;

        if (DataScene.stateOwner == StateOwner.IsServer)
        {
            createLobbyButton.gameObject.SetActive(false);
            joinLobbyButton.gameObject.SetActive(false);
            return;
        }
        createLobbyButton.gameObject.SetActive(true);
        joinLobbyButton.gameObject.SetActive(true);
    }
    protected override void Init()
    {
        gameUI.SetActive(false);
    }

}
