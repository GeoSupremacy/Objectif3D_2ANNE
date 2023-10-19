using System;
using System.Net.Http;

namespace APIFetcher
{
    internal class NetworkAPI
    {
        public static async void GetRandomQuote()
        {
            HttpClient _request = new HttpClient();
            HttpResponseMessage _mesage = await _request.GetAsync(API.GetSeveralRandomQuote);
        }
        public NetworkAPI() { }
    }
}
