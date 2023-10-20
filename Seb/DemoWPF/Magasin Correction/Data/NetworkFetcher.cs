using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Magasin_Correction
{
    internal class NetworkFetcher
    {
        public static event Action<Deal[]> OnDealIsDowLoad = null;
        public static event Action OnBeginDownload= null;
        public static event Action OnEndDownload = null;
        public static event Action OnFailDownload = null;

        public static event Action<Store[]> OnStoreIsDowLoad = null;

        static HttpClient dealRequest= new HttpClient();
        public static async void GetAllDeals(int _pageNumber =0)
        {
            try 
            {
                //OnBeginDownload?.Invoke();
                HttpResponseMessage _msg = await dealRequest.GetAsync(API.Deals(_pageNumber));
                string _rslt =await _msg.Content.ReadAsStringAsync();
                Deal[] _deals = JsonConvert.DeserializeObject<Deal[]>(_rslt);
                if (_deals.Equals(null))
                    throw new Exception("Wong DATA");
                OnDealIsDowLoad?.Invoke(_deals);
                OnEndDownload?.Invoke();
               // MessageBox.Show(_rslt);
            }
            catch (Exception _e)
            {
                OnFailDownload?.Invoke();
                MessageBox.Show(_e.Message);
            }
        }

        public static async void GetAllStores()
        {
            try
            {
              
                HttpResponseMessage _msg = await dealRequest.GetAsync(API.StoresURL);
                string _rslt = await _msg.Content.ReadAsStringAsync();
                Store[] _stores = JsonConvert.DeserializeObject<Store[]>(_rslt);
                if (_stores.Equals(null))
                    throw new Exception("Wong DATA");
                OnStoreIsDowLoad?.Invoke(_stores);
            }
            catch (Exception _e)
            {
                OnFailDownload?.Invoke();
                MessageBox.Show(_e.Message);
            }
        }
    }
}
