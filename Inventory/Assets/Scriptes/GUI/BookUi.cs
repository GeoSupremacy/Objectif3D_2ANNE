using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BookUi : MonoBehaviour
{
    #region Action
    public static event Action OnQuit = null;
    public static event Action<Book> OnDisplay = null;
    #endregion
    #region GameObject
    [SerializeField] GameObject inventoryUI;
    [SerializeField] GameObject ButtonPage;
    #endregion
    
    #region Content
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text publisherText;
    [SerializeField] 
    private TMP_Text PublishedDateText;
    [SerializeField]
    private TMP_Text DescriptionText;
    [SerializeField]
    private TMP_Text languageText;

    #region VolumeInfo
    [SerializeField] 
    private Button ebookReviewButton;
    [SerializeField] 
    private Button InfoGoogleLinkButton;
    [SerializeField]
    private Button OfficialLinkButton;
    #endregion

    #region PriceInfo
    [SerializeField]
    private TMP_Text ListPriceText;
    [SerializeField]
    private TMP_Text RetailPriceText;
    [SerializeField]
    private TMP_Text SaleabilityText;
    [SerializeField]
    private TMP_Text AmountText;
    [SerializeField]
    private TMP_Text CurrencyCodeText;
    [SerializeField]
    private TMP_Text RetailAmountText;
    [SerializeField]
    private TMP_Text RetailCurrencyCodeText;
    [SerializeField]
    private Button BuyLinkButton;
     #endregion

    #region AcessInfo
    [SerializeField]
    private TMP_Text ItIsNestableText;
    [SerializeField]
    private TMP_Text ItIsPublicDomainText;
    [SerializeField]
    private TMP_Text AccessViewStatusText;
    [SerializeField]
    private Button pDFButton;
    [SerializeField]
    private Button EpubLinkButton;
    [SerializeField]
    private Button WebReaderLinkButton;
    #endregion
    [SerializeField]
    private Button quitButton;
    #endregion
    bool IsValidUI => image && DescriptionText && WebReaderLinkButton && EpubLinkButton && pDFButton && AccessViewStatusText && ItIsPublicDomainText && ItIsNestableText && ListPriceText && RetailPriceText && RetailCurrencyCodeText && RetailAmountText && BuyLinkButton && CurrencyCodeText && AmountText&& SaleabilityText && titleText && publisherText && PublishedDateText && languageText && quitButton && OfficialLinkButton && InfoGoogleLinkButton && ebookReviewButton;
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
        
        if (!IsValidUI)
        {
            Debug.Log("BookUi problem UI");
            return;
        }
        
        titleText.text = _currentBook.VolumeInfo.Title;
        //ReviewStringWithTwoMessage(publisherText.text, _currentBook.VolumeInfo.Publisher, "Publisher not found else", "Publisher ");
        //ReviewStringWithOneMessage(PublishedDateText.text, _currentBook.VolumeInfo.PublishedDate, "Published Date: ");
        //ReviewStringWithOneMessage(DescriptionText.text, _currentBook.VolumeInfo.Description, "Description: ");
        //ReviewStringWithOneMessage(languageText.text, _currentBook.VolumeInfo.Language, "Language: ");
         publisherText.text = _currentBook.VolumeInfo.Publisher == null || _currentBook.VolumeInfo.Publisher.Length==0 ? publisherText.text = "Publisher not found else" : publisherText.text = "Publisher "+_currentBook.VolumeInfo.Publisher;
        PublishedDateText.text = _currentBook.VolumeInfo.PublishedDate != null ? "Published Date: " + _currentBook.VolumeInfo.PublishedDate: "";
       DescriptionText.text = _currentBook.VolumeInfo.Description != null ?"Description: " + _currentBook.VolumeInfo.Description: "";
        languageText.text = _currentBook.VolumeInfo.Language!= null ? "Language: " +_currentBook.VolumeInfo.Language: "";
       
        ebookReviewButton.name = "Ebook Review: ";
        InfoGoogleLinkButton.name = "Info Link: ";
        
         if(_currentBook.VolumeInfo.CanonicalVolumeLink == _currentBook.VolumeInfo.InfoLink)
            OfficialLinkButton.gameObject.SetActive(false);

        //ReviewStringWithOneMessage(ListPriceText.text, _currentBook.SaleInfo.ListPrice, "List Price: ");
        //ReviewStringWithOneMessage(RetailPriceText.text, _currentBook.SaleInfo.RetailPrice, "Retail Price: ");
        //ReviewStringWithOneMessage(AmountText.text,  _currentBook.SaleInfo.ListPrice, string.Format("{0:N3}", _currentBook.SaleInfo.ListPrice.Amount), "Amount: ");
        //ReviewStringWithOneMessage(CurrencyCodeText.text, _currentBook.SaleInfo.ListPrice, _currentBook.SaleInfo.ListPrice.CurrencyCode, "Currency code: ");
        //ReviewStringWithOneMessage(RetailAmountText.text, _currentBook.SaleInfo.ListPrice, string.Format("{0:N3}", _currentBook.SaleInfo.RetailPrice.Amount), "Amount: " );
        //ReviewStringWithOneMessage(RetailCurrencyCodeText.text, _currentBook.SaleInfo.ListPrice,_currentBook.SaleInfo.RetailPrice.CurrencyCode, "Currency code: ");
        SaleabilityText.text = _currentBook.SaleInfo.Saleability;


         ListPriceText.text = _currentBook.SaleInfo.ListPrice != null ? "List Price: " : "";
        RetailPriceText.text = _currentBook.SaleInfo.RetailPrice != null ? "Retail Price: " : "";

         AmountText.text =  _currentBook.SaleInfo.ListPrice != null? "Amount: " + _currentBook.SaleInfo.ListPrice.Amount : "";
        CurrencyCodeText.text = _currentBook.SaleInfo.ListPrice != null ? "Currency code: " + _currentBook.SaleInfo.ListPrice.CurrencyCode : "";
         RetailAmountText.text = _currentBook.SaleInfo.ListPrice != null ? "Amount: " + _currentBook.SaleInfo.RetailPrice.Amount : "";
         RetailCurrencyCodeText.text = _currentBook.SaleInfo.ListPrice != null ? "Currency code: " + _currentBook.SaleInfo.RetailPrice.CurrencyCode : "";
        BuyLinkButton.name = "Buy Link: ";

        //ReviewString(ItIsNestableText.text, "It's Nestable");
        //ReviewString(ItIsPublicDomainText.text,"It's Public domain");
        //ReviewStringWithOneMessage(AccessViewStatusText.text, _currentBook.AccessInfo.AccessViewStatus, "Access View Status: ");
        ItIsNestableText.text = _currentBook.AccessInfo.Embeddable ? "It's Nestable" : "";
        ItIsPublicDomainText.text= _currentBook.AccessInfo.Embeddable ? "It's Public domain" : "";
        AccessViewStatusText.text = _currentBook.AccessInfo.AccessViewStatus != null  ? "Access View Status: " + _currentBook.AccessInfo.AccessViewStatus : "";


        ReviewLink(_currentBook.AccessInfo.Pdf.DownloadLink, pDFButton, _currentBook.AccessInfo.Pdf.IsAvailable);
        ReviewLink(_currentBook.AccessInfo.Epub.DownloadLink, EpubLinkButton, _currentBook.AccessInfo.Epub.IsAvailable);
       

        ReviewLink(_currentBook.SaleInfo.BuyLink, BuyLinkButton);

        ReviewLink(_currentBook.VolumeInfo.PreviewLink, ebookReviewButton);
        ReviewLink(_currentBook.VolumeInfo.InfoLink,InfoGoogleLinkButton);
        ReviewLink(_currentBook.VolumeInfo.PreviewLink,OfficialLinkButton);

        ReviewLink(_currentBook.AccessInfo.WebReaderLink, WebReaderLinkButton);


        StartCoroutine(NetworkFetcher.LoadImage(_currentBook.VolumeInfo.ImageLinks.thumbnail));
       

        ButtonPage.gameObject.SetActive(true);
        inventoryUI.gameObject.SetActive(false);
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

    private void ReviewLink(string _link, Button _button)
    {
        if (_link == null || _link == string.Empty)
        
            _button.gameObject.SetActive(false);
            else
            _button.onClick.AddListener(() => Application.OpenURL(_link));
        
    }
    private void ReviewLink(string _link, Button _button, bool _available)
    {
        if (!_available || _link == string.Empty)
            _button.gameObject.SetActive(false);
        else
            _button.onClick.AddListener(() => Application.OpenURL(_link));
        
    }
    private void ReviewStringWithTwoMessage(string _text, string _string, string _message1, string _message2)=>   _text = _string == null || _string.Length <= 0 ? _text = _message1 : _text = _message2 + _string;
    private void ReviewStringWithOneMessage(string _text, string _string, string _message1)=>   _text = _string != string.Empty || _string.Length == 0 ? _text = _message1 + _string : _text = "";
    private void ReviewString(string _text, string _string, string _message)=>   _text = _string != null ? _text = _message : _text = "";
    private void ReviewString(string _text, string _string)=>   _text = _string != null ? _text = _string : _text = "";
    private void ReviewStringWithOneMessage(string _text, object _object, string _message1)=>   _text = _object != null ? _text = _message1 : _text = "";
    private void ReviewStringWithOneMessage(string _text, object _object, string _string, string _message1) => _text = _object != null ? _text = _message1+ _string : _text = "";
}
