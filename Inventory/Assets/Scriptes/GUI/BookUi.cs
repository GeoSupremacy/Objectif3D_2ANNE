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


    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject ButtonPage;

    
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text publisherText;
    [SerializeField] 
    private TMP_Text PublishedDateText;
    [SerializeField]
    private TMP_Text languageText;

    [SerializeField] 
    private Button ebookReviewButton;
    [SerializeField] 
    private Button InfoGoogleLinkButton;
    [SerializeField]
    private Button OfficialLinkButton;

    [SerializeField]
    private TMP_Text SaleabilityText;
    [SerializeField]
    private TMP_Text AmountText;
    [SerializeField]
    private TMP_Text CurrencyCodeText;

    [SerializeField]
    private Button BuyLinkButton;
    [SerializeField]
    private Button quitButton;
    bool IsValidUI => image && BuyLinkButton && CurrencyCodeText && AmountText&& SaleabilityText && titleText && publisherText && PublishedDateText && languageText && quitButton && OfficialLinkButton && InfoGoogleLinkButton && ebookReviewButton;
    private void Awake()
    {

        InventoryUI.OnBookUI += DisplayInfo;
        ButtonPage?.gameObject.SetActive(false);
        OnQuit += QuitMenu;
        //When Coroutine End
        NetworkFetcher.OnImage += SetImage;
    }
    void Start() => InitUI();
    void DisplayInfo(Book _currentBook)
    {
        OnDisplay?.Invoke(_currentBook);

        if(!IsValidUI)
        {
            Debug.Log("BookUi problem UI");
            return;
        }

        titleText.text = _currentBook.VolumeInfo.Title;
        publisherText.text = _currentBook.VolumeInfo.Publisher =="" ? publisherText.text = "Publisher not found else" : publisherText.text = "Publisher "+_currentBook.VolumeInfo.Publisher;
        PublishedDateText.text = "Published Date: " + _currentBook.VolumeInfo.PublishedDate;
        languageText.text = "Language: "+_currentBook.VolumeInfo.Language;

        ebookReviewButton.name = "Ebook Review: ";
        InfoGoogleLinkButton.name = "Info Link: ";
        OfficialLinkButton.name = _currentBook.VolumeInfo.CanonicalVolumeLink == _currentBook.VolumeInfo.InfoLink? OfficialLinkButton.name ="": OfficialLinkButton.name = "Official link: ";
        if(_currentBook.VolumeInfo.CanonicalVolumeLink == _currentBook.VolumeInfo.InfoLink)
            OfficialLinkButton.gameObject.SetActive(false);
        
        SaleabilityText.text = _currentBook.SaleInfo.Saleability;
        AmountText.text =  _currentBook.SaleInfo.ListPrice != null? "Amount: " + _currentBook.SaleInfo.ListPrice.Amount : "";
        CurrencyCodeText.text = _currentBook.SaleInfo.ListPrice != null ? "Currency code: " + _currentBook.SaleInfo.ListPrice.CurrencyCode : "";
        BuyLinkButton.name= "Buy Link: ";

        ebookReviewButton.onClick.AddListener(() => Application.OpenURL(_currentBook.VolumeInfo.PreviewLink));
        InfoGoogleLinkButton.onClick.AddListener(() => Application.OpenURL(_currentBook.VolumeInfo.InfoLink));
        OfficialLinkButton.onClick.AddListener(() => Application.OpenURL(_currentBook.VolumeInfo.PreviewLink));

        BuyLinkButton.onClick.AddListener(() => Application.OpenURL(_currentBook.SaleInfo.BuyLink));


        StartCoroutine(NetworkFetcher.LoadImage(_currentBook.VolumeInfo.ImageLinks.thumbnail));
       


        ButtonPage?.gameObject.SetActive(true);
        inventoryUI?.gameObject.SetActive(false);
    }
    void InitUI()=>  quitButton.onClick.AddListener(() => OnQuit?.Invoke());
    void SetImage(Texture2D _newTexture) => image.texture = _newTexture; 
    
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
