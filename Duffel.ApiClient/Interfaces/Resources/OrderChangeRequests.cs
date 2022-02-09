using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class OrderChangeRequests
    {
        private readonly HttpClient _httpClient;

        public OrderChangeRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderChangeResponse> Create(OrderChangeRequest request)
        {
            var payload = OrderChangeConverter.Serialize(request);
            
            var result = await _httpClient.PostAsync($"air/order_change_requests",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            
            return OrderChangeConverter.Deserialize(content);
        }

        public async Task<OrderChangeResponse> Get(string orderChangeRequestId)
        {
            var result = await _httpClient.GetAsync($"/air/order_change_requests/{orderChangeRequestId}");
            var content = await result.Content.ReadAsStringAsync();
            
            return OrderChangeConverter.Deserialize(content);
        }
    }
}