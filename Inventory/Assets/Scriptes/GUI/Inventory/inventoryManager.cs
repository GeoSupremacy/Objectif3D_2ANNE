using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    public event Action OnOpenInventory = null;
    public event Action OnCloseInventory = null;
    public event Action OnQuit = null;


    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject mainGamePage;


    [SerializeField]
    private Button openInventoryButton;
    [SerializeField]
    private Button closeInventoryButton;
    [SerializeField]
    private Button quitMenuButton;
    bool IsValidUI => openInventoryButton && closeInventoryButton && quitMenuButton;
    private void Awake()
    {
        OnOpenInventory += OpenInventory;
        OnCloseInventory += CloseInventory;
        OnQuit += QuitMenu;
    }
    void Start() => InitUI();

    void InitUI()
    {
        if (!IsValidUI)
        {
            Debug.Log("Button or action is empty!");
            return;
        }
        openInventoryButton.onClick.AddListener(() => OnOpenInventory?.Invoke());
        closeInventoryButton.onClick?.AddListener(() => OnCloseInventory?.Invoke());
        quitMenuButton.onClick?.AddListener(() => OnQuit?.Invoke());
  
        closeInventoryButton?.gameObject.SetActive(false);
        openInventoryButton?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OpenInventory()
    {
        quitMenuButton?.gameObject.SetActive(false);
        openInventoryButton?.gameObject.SetActive(false);
        mainGamePage?.gameObject.SetActive(false);

        closeInventoryButton?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(true);
       
       
    }
    private void CloseInventory()
    {
        openInventoryButton?.gameObject.SetActive(true);
        quitMenuButton?.gameObject.SetActive(true);
        closeInventoryButton?.gameObject.SetActive(false);
        mainGamePage?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
        
    }
    private void QuitMenu()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    private void OnDestroy()
    {
        OnOpenInventory = null;
        OnCloseInventory = null;
        OnQuit = null;
    }
}//
