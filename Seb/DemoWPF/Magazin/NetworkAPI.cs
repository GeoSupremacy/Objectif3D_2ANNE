using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magazin
{
    internal class NetworkAPI
    {
        public static event Action<List<Game>> OnGame = null;
        public  static List<Game> listGame =new List<Game>();
        public static async void GetGame()
        {
            HttpClient _request = new HttpClient(); 


            HttpResponseMessage _msg = await _request.GetAsync(API.GetListOfGamesSteam("batman")); 

            string _result = await _msg.Content.ReadAsStringAsync();

            listGame = JsonConvert.DeserializeObject<List<Game>>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs

          //OnGame?.Invoke(listGame);

        }
       
    }
}
