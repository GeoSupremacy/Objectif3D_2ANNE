
using System.Collections.Generic;
using System.Diagnostics;

public class API
{

    public static string chooseTerm = "intitle";
    public const string API_KEY = "AIzaSyAhfryd2Nq8X4VxtN8zZkSKSqVOKGH9LVo";
    public const string DOMAIN = "https://www.googleapis.com/books/v1/";
    public static string Volume => $"{DOMAIN}volumes?q={Search}+{chooseTerm}";
    public static string Search { get; set; } = "flowers";

   
}


/*
{
    "kind": "books#volumes",
      "totalItems": 647,
      "items": [
            {
        "kind": "books#volume",
          "id": "qBxhhMkSLRMC",
          "etag": "B1ILCRBIws8",
          "selfLink": "https://www.googleapis.com/books/v1/volumes/qBxhhMkSLRMC",
          "volumeInfo": 
                {
            "title": "Trippings in Author-land",
                        "authors": ["Emily Chubbuck Judson" ],
                "publishedDate": "1846",
              
                
                "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=qBxhhMkSLRMC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
                        "thumbnail": "http://books.google.com/books/content?id=qBxhhMkSLRMC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
                                },
                "language": "en",
                "previewLink": "http://books.google.fr/books?id=qBxhhMkSLRMC&pg=PA98&dq=flowers+inauthor&hl=&cd=1&source=gbs_api",
                "infoLink": "https://play.google.com/store/books/details?id=qBxhhMkSLRMC&source=gbs_api",
                "canonicalVolumeLink": "https://play.google.com/store/books/details?id=qBxhhMkSLRMC"
              },    
          "saleInfo": 
                {
                    "saleability": "FREE",
                    "isEbook": true,
                    "buyLink": "https://play.google.com/store/books/details?id=qBxhhMkSLRMC&rdid=book-qBxhhMkSLRMC&rdot=1&source=gbs_api"
                  },
          "accessInfo": {
            
                "embeddable": true,
                "publicDomain": true,
                "textToSpeechPermission": "ALLOWED",
                "epub": {
                "isAvailable": false,
                        "downloadLink": "http://books.google.fr/books/download/Trippings_in_Author_land.epub?id=qBxhhMkSLRMC&hl=&output=epub&source=gbs_api"
                        },
                "pdf": {
                "isAvailable": true,
                        "downloadLink": "http://books.google.fr/books/download/Trippings_in_Author_land.pdf?id=qBxhhMkSLRMC&hl=&output=pdf&sig=ACfU3U2ecOY2qN_n_Yb4XgK-xWCBidj18g&source=gbs_api"
                        },
                "webReaderLink": "http://play.google.com/books/reader?id=qBxhhMkSLRMC&hl=&source=gbs_api",
                "accessViewStatus": "FULL_PUBLIC_DOMAIN",
                "quoteSharingAllowed": false
          },
          "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers\u003c/b\u003e bloomed and faded , leaving their places to brighter \u003cb\u003eflowers\u003c/b\u003e still ; the brooks frolicked and jostled their tiny drops together ; and the birds answered back from ten thousand fresh green coverts with startling bursts of&nbsp;..."
          }
    },
     {
        "kind": "books#volume",
      "id": "oAXHCgAAQBAJ",
      "etag": "D85gamf4NJg",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/oAXHCgAAQBAJ",
      "volumeInfo": {
            "title": "AngularJS for .NET Developers in 24 Hours, Sams Teach Yourself",
        "authors": [
          "Dennis Sheppard",
          "Christopher Miller",
          "AJ Liptak"
        ],
        "publisher": "Sams Publishing",
        "publishedDate": "2015-10-19",
        "description": "In just 24 sessions of one hour or less, you will be up and running with AngularJS in your Microsoft .NET environment. Using a straightforward, step-by-step approach, each lesson builds on your .NET skills and knowledge, helping you quickly learn the essentials of AngularJS, and use it to streamline any web development project. Step-by-step instructions carefully walk you through the most common questions, issues, and tasks. Q&A sections, quizzes, and exercises help you build and test your knowledge. By The Way notes present interesting pieces of information. Try it Yourself sidebars offer advice or teach an easier way to do something. Watch Out! cautions advise you about potential problems and help you steer clear of disaster. Dennis Sheppard is a Front-End Architect at NextTier Education in Chicago, IL. He has delivered enterprise solutions for the private equity, insurance, healthcare, education, and distribution industries. Christopher Miller is an Architect at West Monroe Partners. He has built solutions for the higher education, private equity, and renewable energy industries. AJ Liptak, is a Senior Consultant at West Monroe Partners specializing in modern web application development. He has delivered transformative solutions for the telecom, healthcare, finance, and distribution industries. Learn how to... Build AngularJS web apps from scratch, or integrate with existing .NET code Organize, reuse, and test JavaScript web application code far more effectively Discover key JavaScript design patterns that support AngularJS (and their similarities to C#) Use AngularJS modules, controllers, views, data-binding, and event handling Implement AngularJS services efficiently Work with directives, custom directives, and dependency injection Set up AngularJS routing Apply best practices for organizing AngularJS applications Master sophisticated AngularJS techniques, including filters, advanced patterns, and communication between controllers Deploy AngularJS code to the Microsoft Azure cloud Unit-test and debug your single page applications Integrate AngularJS with .NET Web Forms and .NET MVC Build REST APIs in .NET and consume their services in AngularJS Combine AngularJS with .NET SignalR to build real-time web apps Extend AngularJS development with bower, gulp, and webstorm Preview the future of AngularJS: Version 2.0 and beyond",
        "industryIdentifiers": [
          {
                "type": "ISBN_13",
            "identifier": "9780134315058"
          },
          {
                "type": "ISBN_10",
            "identifier": "0134315057"
          }
        ],
        "readingModes": {
                "text": true,
          "image": true
        },
        "pageCount": 714,
        "printType": "BOOK",
        "categories": [
          "Computers"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": true,
        "contentVersion": "1.7.6.0.preview.3",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=oAXHCgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=oAXHCgAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=oAXHCgAAQBAJ&pg=PT117&dq=flowers+inauthor&hl=&cd=2&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=oAXHCgAAQBAJ&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=oAXHCgAAQBAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FOR_SALE",
        "isEbook": true,
        "listPrice": {
                "amount": 17.92,
          "currencyCode": "EUR"
        },
        "retailPrice": {
                "amount": 12.54,
          "currencyCode": "EUR"
        },
        "buyLink": "https://play.google.com/store/books/details?id=oAXHCgAAQBAJ&rdid=book-oAXHCgAAQBAJ&rdot=1&source=gbs_api",
        "offers": [
          {
                "finskyOfferType": 1,
            "listPrice": {
                    "amountInMicros": 17920000,
              "currencyCode": "EUR"
            },
            "retailPrice": {
                    "amountInMicros": 12540000,
              "currencyCode": "EUR"
            },
            "giftable": true
          }
        ]
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "PARTIAL",
        "embeddable": true,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED_FOR_ACCESSIBILITY",
        "epub": {
                "isAvailable": true,
          "acsTokenLink": "http://books.google.fr/books/download/AngularJS_for_NET_Developers_in_24_Hours-sample-epub.acsm?id=oAXHCgAAQBAJ&format=epub&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
        },
        "pdf": {
                "isAvailable": true,
          "acsTokenLink": "http://books.google.fr/books/download/AngularJS_for_NET_Developers_in_24_Hours-sample-pdf.acsm?id=oAXHCgAAQBAJ&format=pdf&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
        },
        "webReaderLink": "http://play.google.com/books/reader?id=oAXHCgAAQBAJ&hl=&source=gbs_api",
        "accessViewStatus": "SAMPLE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers\u003c/b\u003e+\u003cb\u003einauthor\u003c/b\u003e:keyes will search for any title containing the string “\u003cb\u003eflowers\u003c/b\u003e” by an author that matches the name “keyes”, such as \u003cb\u003eFlowers\u003c/b\u003e for Algernon. Hour 9. Using Built-In Directives What You&#39;ll Learn in This."
      }
    },
    {
        "kind": "books#volume",
      "id": "EWhGAQAAMAAJ",
      "etag": "O+8u9zHWU8o",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/EWhGAQAAMAAJ",
      "volumeInfo": {
            "title": "The Naturalist",
        "publishedDate": "1888",
        "industryIdentifiers": [
          {
                "type": "OTHER",
            "identifier": "UCBK:C063039377"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 472,
        "printType": "BOOK",
        "categories": [
          "Geology"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "0.3.8.0.full.1",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=EWhGAQAAMAAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=EWhGAQAAMAAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=EWhGAQAAMAAJ&pg=PA206&dq=flowers+inauthor&hl=&cd=3&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=EWhGAQAAMAAJ&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=EWhGAQAAMAAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FREE",
        "isEbook": true,
        "buyLink": "https://play.google.com/store/books/details?id=EWhGAQAAMAAJ&rdid=book-EWhGAQAAMAAJ&rdot=1&source=gbs_api"
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "ALL_PAGES",
        "embeddable": true,
        "publicDomain": true,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false,
          "downloadLink": "http://books.google.fr/books/download/The_Naturalist.epub?id=EWhGAQAAMAAJ&hl=&output=epub&source=gbs_api"
        },
        "pdf": {
                "isAvailable": false
        },
        "webReaderLink": "http://play.google.com/books/reader?id=EWhGAQAAMAAJ&hl=&source=gbs_api",
        "accessViewStatus": "FULL_PUBLIC_DOMAIN",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers in author&#39;s\u003c/b\u003e garden , Lincoln ( p . 264 ) ; M. pedicularius Sturm , occurs to author commonly on the same plants and in the same localities in and near Lincoln as the last - mentioned ( p . 264 ) ; M. ovatus Sturm , Chat Moss ,&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "Q-LQCwAAQBAJ",
      "etag": "JJH6zDAA4Ug",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/Q-LQCwAAQBAJ",
      "volumeInfo": {
            "title": "Freedom's Orator",
        "subtitle": "Mario Savio and the Radical Legacy of the 1960s",
        "authors": [
          "Robert Cohen"
        ],
        "publisher": "Oxford University Press",
        "publishedDate": "2009-08-27",
        "description": "Here is the first biography of Mario Savio, the brilliant leader of Berkeley's Free Speech Movement, the largest and most disruptive student rebellion in American history. Savio risked his life to register black voters in Mississippi in the Freedom Summer of 1964 and did more than anyone to bring daring forms of non-violent protest from the civil rights movement to the struggle for free speech and academic freedom on American campuses. Drawing upon previously unavailable Savio papers, as well as oral histories from friends and fellow movement leaders, Freedom's Orator illuminates Mario's egalitarian leadership style, his remarkable eloquence, and the many ways he embodied the youthful idealism of the 1960s. The book also narrates, for the first time, his second phase of activism against \"Reaganite Imperialism\" in Central America and the corporatization of higher education. Including a generous selection of Savio's speeches, Freedom's Orator speaks with special relevance to a new generation of activists and to all who cherish the '60s and democratic ideals for which Savio fought so selflessly.",
        "industryIdentifiers": [
          {
                "type": "ISBN_13",
            "identifier": "9780199720354"
          },
          {
                "type": "ISBN_10",
            "identifier": "0199720355"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 544,
        "printType": "BOOK",
        "categories": [
          "History"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "preview-1.0.0",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=Q-LQCwAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=Q-LQCwAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=Q-LQCwAAQBAJ&pg=PA478&dq=flowers+inauthor&hl=&cd=4&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=Q-LQCwAAQBAJ&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=Q-LQCwAAQBAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FOR_SALE",
        "isEbook": true,
        "listPrice": {
                "amount": 24.37,
          "currencyCode": "EUR"
        },
        "retailPrice": {
                "amount": 17.06,
          "currencyCode": "EUR"
        },
        "buyLink": "https://play.google.com/store/books/details?id=Q-LQCwAAQBAJ&rdid=book-Q-LQCwAAQBAJ&rdot=1&source=gbs_api",
        "offers": [
          {
                "finskyOfferType": 1,
            "listPrice": {
                    "amountInMicros": 24370000,
              "currencyCode": "EUR"
            },
            "retailPrice": {
                    "amountInMicros": 17060000,
              "currencyCode": "EUR"
            },
            "giftable": true
          }
        ]
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "PARTIAL",
        "embeddable": true,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false
        },
        "pdf": {
                "isAvailable": true,
          "acsTokenLink": "http://books.google.fr/books/download/Freedom_s_Orator-sample-pdf.acsm?id=Q-LQCwAAQBAJ&format=pdf&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
        },
        "webReaderLink": "http://play.google.com/books/reader?id=Q-LQCwAAQBAJ&hl=&source=gbs_api",
        "accessViewStatus": "SAMPLE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003ein author&#39;s\u003c/b\u003e possession. Savio&#39;s poems are the only introspective writings of his to which I have had access that ... \u003cb\u003eflowers\u003c/b\u003e,” unpublished poem, copy \u003cb\u003ein author&#39;s\u003c/b\u003e possession. 6. Mario Savio to Art Gatti, March 31 [c. 1972], copy \u003cb\u003ein\u003c/b\u003e&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "Vrl13goK-VcC",
      "etag": "nu02dwfro3Q",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/Vrl13goK-VcC",
      "volumeInfo": {
            "title": "How to Photograph Flowers",
        "authors": [
          "Heather Angel"
        ],
        "publisher": "Stackpole Books",
        "publishedDate": "1998",
        "description": "Heather Angel, internationally known nature photographer and author, describes equipment, film, lighting, composition, and special techniques for photographing flowers in the wild and in gardens. Straightforward explanations focus on the particular challenges of taking beautiful flower photographs, such as wind, light, and problem colors. The book also includes tips on making money from nature photography. 131 color photos.",
        "industryIdentifiers": [
          {
                "type": "ISBN_10",
            "identifier": "0811724557"
          },
          {
                "type": "ISBN_13",
            "identifier": "9780811724555"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 148,
        "printType": "BOOK",
        "categories": [
          "Flowers"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "0.2.3.0.preview.1",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=Vrl13goK-VcC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=Vrl13goK-VcC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=Vrl13goK-VcC&pg=PA20&dq=flowers+inauthor&hl=&cd=5&source=gbs_api",
        "infoLink": "http://books.google.fr/books?id=Vrl13goK-VcC&dq=flowers+inauthor&hl=&source=gbs_api",
        "canonicalVolumeLink": "https://books.google.com/books/about/How_to_Photograph_Flowers.html?hl=&id=Vrl13goK-VcC"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "NOT_FOR_SALE",
        "isEbook": false
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "PARTIAL",
        "embeddable": true,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false
        },
        "pdf": {
                "isAvailable": true,
          "acsTokenLink": "http://books.google.fr/books/download/How_to_Photograph_Flowers-sample-pdf.acsm?id=Vrl13goK-VcC&format=pdf&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
        },
        "webReaderLink": "http://play.google.com/books/reader?id=Vrl13goK-VcC&hl=&source=gbs_api",
        "accessViewStatus": "SAMPLE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "Heather Angel. HOW TO PHOTOGRAPH \u003cb\u003eFLOWERS\u003c/b\u003e 23 Water lily ( Nymphaea &quot; Attraction &quot; ) \u003cb\u003ein author&#39;s\u003c/b\u003e garden pond , Surrey , England , June . Hasselblad 500 C / M , 150mm f / 4 Son- nar lens , Ektachrome 100 Plus . If a portrait of a radially&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "lzpQAAAAYAAJ",
      "etag": "fnIZkLHTSAY",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/lzpQAAAAYAAJ",
      "volumeInfo": {
            "title": "Home Garden & Flower Grower",
        "publishedDate": "1973",
        "industryIdentifiers": [
          {
                "type": "OTHER",
            "identifier": "UVA:X004950190"
          }
        ],
        "readingModes": {
                "text": false,
          "image": false
        },
        "pageCount": 62,
        "printType": "BOOK",
        "categories": [
          "Gardening"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "0.3.3.0.preview.0",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=lzpQAAAAYAAJ&printsec=frontcover&img=1&zoom=5&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=lzpQAAAAYAAJ&printsec=frontcover&img=1&zoom=1&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=lzpQAAAAYAAJ&q=flowers+inauthor&dq=flowers+inauthor&hl=&cd=6&source=gbs_api",
        "infoLink": "http://books.google.fr/books?id=lzpQAAAAYAAJ&dq=flowers+inauthor&hl=&source=gbs_api",
        "canonicalVolumeLink": "https://books.google.com/books/about/Home_Garden_Flower_Grower.html?hl=&id=lzpQAAAAYAAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "NOT_FOR_SALE",
        "isEbook": false
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "NO_PAGES",
        "embeddable": false,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false
        },
        "pdf": {
                "isAvailable": false
        },
        "webReaderLink": "http://play.google.com/books/reader?id=lzpQAAAAYAAJ&hl=&source=gbs_api",
        "accessViewStatus": "NONE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers in Author\u003c/b\u003e Frieda Starcevich took these three photo- graphs when she planted the Clavey&#39;s dwarf honeysuckle hedge shown on facing page . The first step was to stretch a line where the hedge was to be planted to assure a straight&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "tT6hwuLVqjgC",
      "etag": "zjYfoU5fdV8",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/tT6hwuLVqjgC",
      "volumeInfo": {
            "title": "Manning on Decoupage",
        "authors": [
          "Hiram Manning"
        ],
        "publisher": "Courier Corporation",
        "publishedDate": "1980-01-01",
        "description": "Clear explanations of every step of every procedure by man who probably knows more about craft than anyone. 91 drawings, over 100 photographs. Index.",
        "industryIdentifiers": [
          {
                "type": "ISBN_10",
            "identifier": "0486240282"
          },
          {
                "type": "ISBN_13",
            "identifier": "9780486240282"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 256,
        "printType": "BOOK",
        "categories": [
          "Crafts & Hobbies"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "1.4.6.0.preview.1",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=tT6hwuLVqjgC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=tT6hwuLVqjgC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=tT6hwuLVqjgC&pg=PA44&dq=flowers+inauthor&hl=&cd=7&source=gbs_api",
        "infoLink": "http://books.google.fr/books?id=tT6hwuLVqjgC&dq=flowers+inauthor&hl=&source=gbs_api",
        "canonicalVolumeLink": "https://books.google.com/books/about/Manning_on_Decoupage.html?hl=&id=tT6hwuLVqjgC"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "NOT_FOR_SALE",
        "isEbook": false
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "PARTIAL",
        "embeddable": true,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false
        },
        "pdf": {
                "isAvailable": true,
          "acsTokenLink": "http://books.google.fr/books/download/Manning_on_Decoupage-sample-pdf.acsm?id=tT6hwuLVqjgC&format=pdf&output=acs4_fulfillment_token&dl_type=sample&source=gbs_api"
        },
        "webReaderLink": "http://play.google.com/books/reader?id=tT6hwuLVqjgC&hl=&source=gbs_api",
        "accessViewStatus": "SAMPLE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers\u003c/b\u003e ( most often embossed Valentine - like \u003cb\u003eflowers\u003c/b\u003e ) massed symmetrically to form a frame for another bouquet ... \u003cb\u003eIn author&#39;s\u003c/b\u003e collection . Never forget that a &quot; style , ” as such. 44 Decoupage : Some Preliminaries."
      }
    },
    {
        "kind": "books#volume",
      "id": "ytWlCgAAQBAJ",
      "etag": "c9TIO/zYQWc",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/ytWlCgAAQBAJ",
      "volumeInfo": {
            "title": "Tell about Night Flowers",
        "subtitle": "Eudora Welty's Gardening Letters, 1940-1949",
        "authors": [
          "Julia Eichelberger"
        ],
        "publisher": "Univ. Press of Mississippi",
        "publishedDate": "2013-05-01",
        "description": "Tell about Night Flowers presents previously unpublished letters by Eudora Welty, selected and annotated by scholar Julia Eichelberger. Welty published many of her best-known works in the 1940s: A Curtain of Green, The Wide Net, The Robber Bridegroom, Delta Wedding, and The Golden Apples. During this period, she also wrote hundreds of letters to two friends who shared her love of gardening. One friend, Diarmuid Russell, was her literary agent in New York; the other, John Robinson, was a high school classmate and an aspiring writer who served in the Army in WWII, and he was long the focus of Welty's affection. Welty's lyrical, witty, and poignant discussions of gardening and nature are delightful in themselves; they are also figurative expressions of Welty's views of her writing and her friendships. Taken together with thirty-five illustrations, they form a poetic narrative of their own, chronicling artistic and psychic developments that were underway before Welty was fully conscious of them. By 1949 her art, like her friendships, had evolved in ways that she would never have predicted in 1940. Tell about Night Flowers not only lets readers glimpse Welty in her garden; it also reveals a brilliant and generous mind responding to the public events, people, art, and natural landscapes Welty encountered at home and on her travels during the 1940s. This book enhances our understanding of the life, landscape, and art of a major American writer.",
        "industryIdentifiers": [
          {
                "type": "ISBN_13",
            "identifier": "9781496800848"
          },
          {
                "type": "ISBN_10",
            "identifier": "1496800842"
          }
        ],
        "readingModes": {
                "text": true,
          "image": true
        },
        "pageCount": 304,
        "printType": "BOOK",
        "categories": [
          "Literary Collections"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "1.1.2.0.preview.3",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=ytWlCgAAQBAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=ytWlCgAAQBAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=ytWlCgAAQBAJ&pg=PT288&dq=flowers+inauthor&hl=&cd=8&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=ytWlCgAAQBAJ&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=ytWlCgAAQBAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FOR_SALE",
        "isEbook": true,
        "listPrice": {
                "amount": 25.01,
          "currencyCode": "EUR"
        },
        "retailPrice": {
                "amount": 25.01,
          "currencyCode": "EUR"
        },
        "buyLink": "https://play.google.com/store/books/details?id=ytWlCgAAQBAJ&rdid=book-ytWlCgAAQBAJ&rdot=1&source=gbs_api",
        "offers": [
          {
                "finskyOfferType": 1,
            "listPrice": {
                    "amountInMicros": 25010000,
              "currencyCode": "EUR"
            },
            "retailPrice": {
                    "amountInMicros": 25010000,
              "currencyCode": "EUR"
            },
            "giftable": true
          }
        ]
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "PARTIAL",
        "embeddable": true,
        "publicDomain": false,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": true
        },
        "pdf": {
                "isAvailable": true
        },
        "webReaderLink": "http://play.google.com/books/reader?id=ytWlCgAAQBAJ&hl=&source=gbs_api",
        "accessViewStatus": "SAMPLE",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003ein Author\u003c/b\u003e and Agent, but the letter replies to DR&#39;s 4.17.42 letter, and the Monday following 4.17.42 is 4.20.42.] EW to DR [Late April 1942] TLS 1 pp [Replies to DR&#39;s letter of April 23 1942] EW to DR May 4 1942 TLS 1 pp EW to DR June 8&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "2SYhAQAAIAAJ",
      "etag": "+D2QnjR9Lyk",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/2SYhAQAAIAAJ",
      "volumeInfo": {
            "title": "Catalog of Copyright Entries",
        "subtitle": "Third series",
        "authors": [
          "Library of Congress. Copyright Office"
        ],
        "publishedDate": "1951",
        "industryIdentifiers": [
          {
                "type": "OTHER",
            "identifier": "STANFORD:36105006281351"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 672,
        "printType": "BOOK",
        "categories": [
          "Copyright"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "1.9.9.0.full.1",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=2SYhAQAAIAAJ&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=2SYhAQAAIAAJ&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=2SYhAQAAIAAJ&pg=PA148&dq=flowers+inauthor&hl=&cd=9&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=2SYhAQAAIAAJ&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=2SYhAQAAIAAJ"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FREE",
        "isEbook": true,
        "buyLink": "https://play.google.com/store/books/details?id=2SYhAQAAIAAJ&rdid=book-2SYhAQAAIAAJ&rdot=1&source=gbs_api"
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "ALL_PAGES",
        "embeddable": true,
        "publicDomain": true,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false,
          "downloadLink": "http://books.google.fr/books/download/Catalog_of_Copyright_Entries.epub?id=2SYhAQAAIAAJ&hl=&output=epub&source=gbs_api"
        },
        "pdf": {
                "isAvailable": false
        },
        "webReaderLink": "http://play.google.com/books/reader?id=2SYhAQAAIAAJ&hl=&source=gbs_api",
        "accessViewStatus": "FULL_PUBLIC_DOMAIN",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eflowers\u003c/b\u003e . ( Playing card art work ) Col. reproductions of painting . 4 x 2 in . ( 1876 ) Walt Disney Productions ... \u003cb\u003ein . Author\u003c/b\u003e of reproduction : Brown and Bigelow . Brown &amp; Bigelow , St. Paul ; 1Jun51 ; H2071 . Cliff swallow . [ Bird ]&nbsp;..."
      }
    },
    {
        "kind": "books#volume",
      "id": "AsM4Q8u1OgUC",
      "etag": "M0DSIyIFh/k",
      "selfLink": "https://www.googleapis.com/books/v1/volumes/AsM4Q8u1OgUC",
      "volumeInfo": {
            "title": "Library Bulletin",
        "authors": [
          "Fitchburg Public Library"
        ],
        "publishedDate": "1896",
        "industryIdentifiers": [
          {
                "type": "OTHER",
            "identifier": "UIUC:30112042813524"
          }
        ],
        "readingModes": {
                "text": false,
          "image": true
        },
        "pageCount": 202,
        "printType": "BOOK",
        "categories": [
          "Catalogs, Classified"
        ],
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": false,
        "contentVersion": "1.3.4.0.full.1",
        "panelizationSummary": {
                "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
                "smallThumbnail": "http://books.google.com/books/content?id=AsM4Q8u1OgUC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=AsM4Q8u1OgUC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.fr/books?id=AsM4Q8u1OgUC&pg=RA1-PA8&dq=flowers+inauthor&hl=&cd=10&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=AsM4Q8u1OgUC&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=AsM4Q8u1OgUC"
      },
      "saleInfo": {
            "country": "FR",
        "saleability": "FREE",
        "isEbook": true,
        "buyLink": "https://play.google.com/store/books/details?id=AsM4Q8u1OgUC&rdid=book-AsM4Q8u1OgUC&rdot=1&source=gbs_api"
      },
      "accessInfo": {
            "country": "FR",
        "viewability": "ALL_PAGES",
        "embeddable": true,
        "publicDomain": true,
        "textToSpeechPermission": "ALLOWED",
        "epub": {
                "isAvailable": false,
          "downloadLink": "http://books.google.fr/books/download/Library_Bulletin.epub?id=AsM4Q8u1OgUC&hl=&output=epub&source=gbs_api"
        },
        "pdf": {
                "isAvailable": false
        },
        "webReaderLink": "http://play.google.com/books/reader?id=AsM4Q8u1OgUC&hl=&source=gbs_api",
        "accessViewStatus": "FULL_PUBLIC_DOMAIN",
        "quoteSharingAllowed": false
      },
      "searchInfo": {
            "textSnippet": "... \u003cb\u003eFlowers\u003c/b\u003e , Trees , Birds and Insects for the Younger Readers . Emerson , R. W. Nature . ( \u003cb\u003eIn author&#39;s\u003c/b\u003e Com- plete works . v . 3 , p . 161. ) Flagg , W. Birds and seasons of New England . 591.9 F Gaye , S. Great world&#39;s farm : some account&nbsp;..."
      }
    }
  ]
}
  ]
}

*/