using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverButton;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(() =>
        {
            Debug.Log("serverButton");
            NetworkManager.Singleton.StartServer();
        });

        hostButton.onClick.AddListener(() =>
        {
            Debug.Log("hostButton");
            NetworkManager.Singleton.StartHost();
        });

        clientButton.onClick.AddListener(() =>
        {
            Debug.Log("clientButton");
            NetworkManager.Singleton.StartClient();
        });
    }
    private void Start()
    {
        serverButton.gameObject.SetActive(true);
        hostButton.gameObject.SetActive(true);
        clientButton.gameObject.SetActive(true);
    }
}
