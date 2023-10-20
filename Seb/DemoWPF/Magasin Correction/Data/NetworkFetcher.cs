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
        public static async void GetAllDeals(int _pageNumber =0)
        {
            try 
            {
                HttpClient _request = new HttpClient();
                HttpResponseMessage _msg = await _request.GetAsync(API.Deals(_pageNumber));
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
    }
}
