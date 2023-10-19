using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    internal class API
    {

        const string BASE_URL = "https://www.cheapshark.com/api/1.0/"; //URL de CheckSharck
       
        public static string GetRandomQuote => $"{BASE_URL}/random";

        public static string GetListOfGames(string _title) => $"{BASE_URL}games?title={_title}";
        public static string GETMultipleGameLookup(string _character = "tyrion", uint _number = 1) => $"{BASE_URL}/author/{_character}/{_number}";

    }
}
