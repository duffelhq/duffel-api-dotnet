using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient
{
    public class DuffelApiClient : IDuffelApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        
        public DuffelApiClient(string accessToken)
        {
            
            _httpClient.BaseAddress = new Uri("https://api.duffel.com");
            
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Duffel-Version", "beta");
            
            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            
        }

        public async Task<OffersResponse> CreateOffersRequest(OffersRequest request)
        {
            // Note: temp code. This will be refactored to use streams, injectable http client, etc.
            var payload = OffersConverter.Serialize(request);
            var result = await _httpClient.PostAsync("air/offer_requests", 
                new StringContent(payload,  Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            return OffersConverter.Deserialize(content);
        }
    }
}