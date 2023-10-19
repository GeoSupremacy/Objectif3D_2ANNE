
using System;
using System.Net.Http;
using System.Windows;
using Newtonsoft.Json;
namespace APIFetcher
{
    internal class NetworkAPI
    {
        public static event Action<Quote> OnRandomQuote = null;
        //lance la méthode en parrallèle et retourne une Task
        public static async void GetRandomQuote()
        {
            HttpClient _request = new HttpClient(); //NE JAMAIS CREE UN HTTPCLIENT dans une boucle
                                                    //toujours le mettre en const en dehors pour optimisé la mémoire


            HttpResponseMessage _msg = await _request.GetAsync(API.GetRandomQuote); //Await = dire au code d'attendre la réponse
                                                                                    //de la requet en async avant de continuer le code

            string _result = await _msg.Content.ReadAsStringAsync(); //ReadAsString = Lire en string
                                                                     //Read as byte = lire des exe ou fichiers plus spécifique

            Quote _quote = JsonConvert.DeserializeObject<Quote>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs
                                                                          //que le json obtenu (voir sur l'API l'utilisation)

            OnRandomQuote?.Invoke(_quote);

        }
    }
}
