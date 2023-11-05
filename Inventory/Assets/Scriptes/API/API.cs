
using System.Collections.Generic;
using System.Diagnostics;

public class API
{

    public static string chooseTerm = "intitle";
    public const string API_KEY = "AIzaSyAhfryd2Nq8X4VxtN8zZkSKSqVOKGH9LVo";
    public const string DOMAIN = "https://www.googleapis.com/books/v1/";
    public static string Volume => $"{DOMAIN}volumes?q={Search}+{chooseTerm}&maxResults=40";
    public static string Search { get; set; }

   
}

