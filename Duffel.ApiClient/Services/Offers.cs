using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;

namespace Duffel.ApiClient.Services
{
    public class Offers
    {
        private readonly HttpClient _httpClient;

        public Offers(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<OffersResponse> Request(OffersRequest request)
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