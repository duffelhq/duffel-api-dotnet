using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;

namespace Duffel.ApiClient.Resources
{
    public interface IOrderChangeRequests
    {
        Task<OrderChangeResponse> Create(OrderChangeRequest request);
        Task<OrderChangeResponse> Get(string orderChangeRequestId);
    }

    public class OrderChangeRequests : IOrderChangeRequests
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
                new StringContent(payload, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChangeResponse>(result);
        }

        public async Task<OrderChangeResponse> Get(string orderChangeRequestId)
        {
            var result = await _httpClient.GetAsync($"/air/order_change_requests/{orderChangeRequestId}").ConfigureAwait(false);
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChangeResponse>(result);
        }
    }
}