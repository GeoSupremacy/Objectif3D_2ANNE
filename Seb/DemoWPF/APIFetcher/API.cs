using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFetcher
{
    internal class API
    {
        public const string BASE_URL = "https://gameofthronesquotes.xyz/";
        //public readonly string TEST = "";
        public static string GetSeveralRandomQuote(uint _number)=>$" {BASE_URL}/rando{_number}";
        public string GetSeveralRandomTyrionQuote(uint _number) => $" {BASE_URL}/random{_number}";
    }
}
