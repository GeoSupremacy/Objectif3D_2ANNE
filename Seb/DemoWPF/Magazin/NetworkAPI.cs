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
        
        public  static List<Deal> listDeal =new List<Deal>();
        public static async void GetGame()
        {
            HttpClient _request = new HttpClient(); 


            HttpResponseMessage _msg = await _request.GetAsync(API.GetListOfDeals()); 

            string _result = await _msg.Content.ReadAsStringAsync();

            listDeal = JsonConvert.DeserializeObject<List<Deal>>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs

          

        }
       
    }
}
