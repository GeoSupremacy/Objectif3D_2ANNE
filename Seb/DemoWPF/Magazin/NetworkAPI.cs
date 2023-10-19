using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Magazin
{
    internal class NetworkAPI
    {

        public static List<Deal> listDeal = new List<Deal>();
        public static List<Store> listStore = new List<Store>();
        public static async void GetGame()
        {
            HttpClient _request = new HttpClient();


            HttpResponseMessage _msg = await _request.GetAsync(API.GetListOfDeals(0, 15, 0));

            string _result = await _msg.Content.ReadAsStringAsync();

            listDeal = JsonConvert.DeserializeObject<List<Deal>>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs



        }
        public static async void SetGame(int _index)
        {
            HttpClient _request = new HttpClient();


            HttpResponseMessage _msg = await _request.GetAsync(API.GetListOfDeals(_index, 15,0));

            string _result = await _msg.Content.ReadAsStringAsync();

            listDeal = JsonConvert.DeserializeObject<List<Deal>>(_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs

        }
        public static async void SetStore()
        {
            HttpClient _request = new HttpClient();


            HttpResponseMessage _msg = await _request.GetAsync(API.GETStoresInfo());

            string _result = await _msg.Content.ReadAsStringAsync();

            listStore = JsonConvert.DeserializeObject<List<Store>>(_result);
        }
    }//
}
