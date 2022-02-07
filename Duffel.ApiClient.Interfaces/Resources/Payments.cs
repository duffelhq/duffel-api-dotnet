using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces.Resources
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
            var content = await result.Content.ReadAsStringAsync();
            
            return PaymentResponseConverter.Deserialize(content);
        }
    }
}