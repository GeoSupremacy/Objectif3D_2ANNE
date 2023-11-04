using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBook
{
   public int TotalItems;
   public List<Book> Items;
}
public class Book
{
    
    public VolumeInfo VolumeInfo;
    public SaleInfo SaleInfo;
    public AccessInfo AccessInfo;
}
public class VolumeInfo
{
    public List<string> Authors;
    public string Title;
    public string Publisher;
    public string PublishedDate;
  
    public List<string> Categories;
    public ImageLinks ImageLinks;
    public string Language;

    
    //Revu ebook
    public string PreviewLink;
    //Page Google Livre
    public string InfoLink;
    //Lien officiel (sinon Google)
    public string CanonicalVolumeLink;
}
public class SaleInfo
{
    public string Saleability;
    public bool IsEbook;
    public ListPrice ListPrice;
    public RetailPrice RetailPrice;
    public string BuyLink;

}
public class ListPrice
{
    public float Amount;
    public string CurrencyCode;

}
public class RetailPrice
{
    public float Amount;
    public string CurrencyCode;

}
public class AccessInfo
{
    public bool Embeddable;
    public bool PublicDomain;

    public Epub Epub;
    public Pdf Pdf;
    public string WebReaderLink;
    public string AccessViewStatus;
    public bool QuoteSharingAllowed;
}
public class ImageLinks
{
    public string SmallThumbnail;
    public string thumbnail;
}
public class Epub
{
   public bool IsAvailable;
   public string DownloadLink;
}
public class Pdf
{
    public bool IsAvailable;
    public string DownloadLink;
}