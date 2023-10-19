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
        public static string GetMultipleGameLookup(string _character = "tyrion", uint _number = 1) => $"{BASE_URL}games?title=";

        //_storeID sert à filtrer les magasins qui a le jeu si non définit affiche tous les magasins
        //upperPrice n'affiche que les prix en dessous ou égale au montant désigner (50 équivaut à aucune limite)
        //D'autre paramètre qui sont optionnel
        public static string GetListOfDeals(string _storeID, string _upperPrice) => $"{BASE_URL}deals?storeID={_storeID}&upperPrice={_upperPrice}";
    }
}
