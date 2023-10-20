using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Magasin_Correction
{
    internal class API
    {
        public const string DOMAIN = "https://www.cheapshark.com/api/1.0/";
        public static string StoresURL => $"{DOMAIN}stores";
        public static string Details(string _dealID) => $"{DOMAIN}games?id={_dealID}";
        public static string Deals(int _page = 1) => Path.Combine(DOMAIN, $"deals?storeID=1&upperPrice=15&pageNumber={_page}");
      
    }
}
