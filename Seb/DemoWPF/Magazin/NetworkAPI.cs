using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    internal class NetworkAPI
    {
        public static event Action<Game> OnGame = null;
        public static async void GetGame()
        {
            HttpClient _request = new HttpClient(); 


            HttpResponseMessage _msg = await _request.GetAsync(API.GetPathAPI()); 

            string _result = await _msg.Content.ReadAsStringAsync(); 

            Game _game = JsonConvert.DeserializeObject<Game>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs
                                                                       //que le json obtenu (voir sur l'API l'utilisation)

            OnGame?.Invoke(_game);

        }
    }
}
