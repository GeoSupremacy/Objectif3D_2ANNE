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
        public static List<Info> Info = new List<Info>();
        public static int index = 0;
        public static async void GetGame()
        {
            HttpClient _request = new HttpClient();


            HttpResponseMessage _msg = await _request.GetAsync(API.GetListOfDeals());

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
            string[] _tab = new string[] { "128", "129", "130"};
            HttpResponseMessage _msg = await _request.GetAsync(API.GetMultipleGameLookupSteam(_tab));

            string _result = await _msg.Content.ReadAsStringAsync();

            Info = JsonConvert.DeserializeObject<List<Info>> (_result); //On deserialise le json obtenu par notre class crée avec les mêmes valeurs

            
            //for(int i =0; i< listDeal.Count; i++)
            //  deal = MainWindow.listdeal[index];
        }
    }//
}
