using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BookUi : MonoBehaviour
{

    public static event Action OnQuit = null;
    public static event Action<Book> OnDisplay = null;
    public static event Action<Texture2D> OnImage = null;


    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject ButtonPage;


    [SerializeField]
    private RawImage image;
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text publisherText;
    [SerializeField]
    private TMP_Text languageText;
    [SerializeField]
    private Button quitButton;
   // bool IsValidUI => openInventoryButton && closeInventoryButton && quitMenuButton;
    private void Awake()
    {

        InventoryUI.OnBookUI += DisplayInfo;
        ButtonPage?.gameObject.SetActive(false);
        OnQuit += QuitMenu;
    }
    void Start() => InitUI();
    void DisplayInfo(Book _currentBook)
    {
        OnDisplay?.Invoke(_currentBook);

        titleText.text = _currentBook.VolumeInfo.Title;
        publisherText.text = _currentBook.VolumeInfo.Publisher =="" ? publisherText.text = "Publisher not found else" : publisherText.text = _currentBook.VolumeInfo.Publisher;
        languageText.text = "Language: "+_currentBook.VolumeInfo.Language;
        // image = _currentBook.VolumeInfo.ImageLink;
        Texture2D _t;
        image.texture = _t;


        ButtonPage?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
    }
    void InitUI()=> quitButton.onClick.AddListener(() => OnQuit?.Invoke());

       
    
    // Start is called before the first frame update
    
    private void QuitMenu()
    {
      
        ButtonPage?.gameObject.SetActive(false);
        inventoryUI?.gameObject.SetActive(true);
       
    }
    private void OnDestroy()
    {
        OnQuit = null;
        OnDisplay = null;
    }
}
