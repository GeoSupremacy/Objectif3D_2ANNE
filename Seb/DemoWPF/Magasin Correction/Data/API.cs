﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Magasin_Correction
{
    internal class API
    {
        public const string DOMAIN = "https://www.cheapshark.com/api/1.0/";
        public static string Deals(int _page = 0) => Path.Combine(DOMAIN, "deals?storesID=1&upperPrice=15&pageNumber", _page.ToString());   
    }
}
