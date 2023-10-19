using System.Windows.Media;

namespace APIFetcher
{
    internal class API
    {

        const string BASE_URL = "https://api.gameofthronesquotes.xyz/v1"; //const initialisé ici mais bloqué ici seulement
        public readonly string TEST = ""; //readonly = initialisé ici ou dans le constructeur

        /*public API(string _str)
		{
			BASE_URL = ""; //Ne peux pas etre modifier
			TEST = ""; //Peut etre réatribué
		}*/
        public static string GetRandomQuote => $"{BASE_URL}/random";

        public static string GetSeveralRandomQuotes(uint _number) => $"{BASE_URL}/random/{_number}";
        public static string GetSeveralRandomCharacterQuotes(string _character = "tyrion", uint _number = 1) => $"{BASE_URL}/author/{_character}/{_number}";


    }
}
