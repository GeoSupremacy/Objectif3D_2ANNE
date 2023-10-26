using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MainUI : MonoBehaviour
{
    public event Action OnPlayButton = null;
    public event Action OnQuitButton = null;
    public event Action OnReturnButton = null;
    public event Action OnInventoryButton = null;


    [SerializeField] Button playButton =null,
                            quitButton =null, 
                            returnButton = null,
                            inventoryButton = null;

    [SerializeField] GameObject inventoryUI = null;
    [SerializeField] GameObject mainGamePage = null;
    
    //Bind Button
    void Awake()
    {
        OnPlayButton += OnPlayUI;
        OnQuitButton += OnQuitUI;
        OnReturnButton += OnReturnUI;
        OnInventoryButton += OpenInventory;
    }
    public bool IsValidUI => playButton && quitButton && returnButton && inventoryUI&& inventoryButton;
    bool isInInventory = false;

    void Start() => InitUI();
    
    void InitUI()
    {
        if (!IsValidUI)
        {
            Debug.Log("Button or action is empty!");
            return;
        }
           
        playButton.onClick.AddListener(() =>OnPlayButton?.Invoke());
        quitButton.onClick.AddListener(() => OnQuitButton?.Invoke());
        returnButton.onClick.AddListener(() => OnReturnButton?.Invoke());
        inventoryButton.onClick.AddListener(() => OnInventoryButton?.Invoke());

        inventoryButton?.gameObject.SetActive(false);
        returnButton?.gameObject.SetActive(false);
        inventoryUI?.gameObject.SetActive(false);
    }
    void HidePage(GameObject _page)
    { 
        _page.SetActive(false); 
       
    }
    void VisiblePage(GameObject _page)
    { 
        _page.SetActive(true); 
    }
    void OnPlayUI()
    {
        HidePage(mainGamePage);
        returnButton?.gameObject.SetActive(true);
        inventoryButton?.gameObject.SetActive(true);
    }
     void OpenInventory()
    {
        isInInventory = true;
        inventoryButton?.gameObject.SetActive(false);
        returnButton?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(true);
    }
    void OnReturnUI()
    {
        if (isInInventory) 
        { 
            isInInventory = false;
            inventoryUI?.gameObject.SetActive(false);
            inventoryButton?.gameObject.SetActive(true);
            return; 
        }
        VisiblePage(mainGamePage);
        inventoryButton?.gameObject.SetActive(false);
        returnButton?.gameObject.SetActive(false);
    }
    void OnQuitUI()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    void OnDestroy()
    {
        OnPlayButton = null;
        OnQuitButton = null;
        OnReturnButton = null;
        OnInventoryButton = null;
    }
}
