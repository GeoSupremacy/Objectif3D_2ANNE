using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    internal class API
    {

        const string BASE_URL = "https://www.cheapshark.com/"; //URL de CheckSharck
        const string BASE_URL_API = "https://www.cheapshark.com/api/1.0/"; //URL API de CheckSharck

        //Dans un jeu steam par nom avec le prix le plus bas
        public static string GetListOfGamesSteam(string _title) => $"{BASE_URL_API}games?title={_title}";
        //Des infos spécifiques du jeu sur Steam
        public static string GetGameLookupSteam(uint _gameID) => $"{BASE_URL_API}games?id={_gameID}";
        //Montre 25 jeu maximum de Steam avec une liste des prix
        public static string GetMultipleGameLookupSteam(string[] _listUID) => $"{BASE_URL_API}games?ids={_listUID}";

        //_storeID sert à filtrer les magasins qui a le jeu si non définit affiche tous les magasins
        //upperPrice n'affiche que les prix en dessous ou égale au montant désigner (50 équivaut à aucune limite)
        //D'autre paramètre qui sont optionnel
        public static string GetListOfDeals(uint _storeID, int _upperPrice) => $"{BASE_URL_API}deals?storeID={_storeID}&upperPrice={_upperPrice}";
        //page de redirection CheapShark pour relier les utilisateurs à une offre spécifique,
        //conçu uniquement pour relier et envoyer vers des offres, n'est pas un point de terminaison de l'API et bloquera l'accès automatisé.
        //Ne peut être automatiser
        public static string GetDeals(uint _dealID) => $"{BASE_URL}/redirect?dealID={_dealID}";

        // Encoder Deal id :X8sebHhbc1Ga0dTkgg59WgyM506af9oNZZJLU9uSrX8
        //Avoir des infos supplémentaire du jeu
        public static string GetDealLookup(uint _id) => $"{BASE_URL_API}deals?id={_id}";

        //Retour une list de ID Store, nom et un drapeau si le magasin est active;
        //include une collection de bannière/logo et icone image pour chaque store
        public static string GETStoresInfo() => $"{BASE_URL_API}stores";
    }
}
