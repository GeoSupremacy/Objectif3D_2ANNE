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

    [SerializeField] Button playButton =null,
                            quitButton =null, 
                            returnButton = null;

    [SerializeField] GameObject inventoryUI = null;
    [SerializeField] GameObject mainGamePage = null;
    void Awake()
    {
        OnPlayButton += OnPlayUI;
        OnQuitButton += OnQuitUI;
        OnReturnButton += OnReturnUI;
        
    }
    public bool IsValidUI => playButton && quitButton && returnButton && inventoryUI;
    // Start is called before the first frame update
    void Start() => InitUI();
    
    void InitUI()
    {
        if (!IsValidUI)
            return;
        playButton.onClick.AddListener(() =>OnPlayButton?.Invoke());
        quitButton.onClick.AddListener(() => OnQuitButton?.Invoke());
        returnButton.onClick.AddListener(() => OnReturnButton?.Invoke());


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
    }
     
    void OnReturnUI()
    {

        VisiblePage(mainGamePage);
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
    }
}
