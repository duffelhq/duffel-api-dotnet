using System;
using System.Net.Http;
using Duffel.ApiClient.Services;

namespace Duffel.ApiClient
{
    public class DuffelApiClient
    {
        public Offers Offers { get; }

        public DuffelApiClient(string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.duffel.com");
            
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("Duffel-Version", "beta");
            
            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            
            Offers = new Offers(httpClient);
        }
    }
}