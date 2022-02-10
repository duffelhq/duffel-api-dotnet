using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;

namespace Duffel.ApiClient.Resources
{
    public class Payments
    {
        private readonly HttpClient _httpClient;

        public Payments(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaymentResponse> Create(PaymentRequest paymentRequest)
        {
            var payload = PaymentResponseConverter.Serialize(paymentRequest);
            
            var result = await _httpClient.PostAsync($"air/payments",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            
            return await SingleItemResponseConverter.GetAndDeserialize<PaymentResponse>(result);
        }
    }
}