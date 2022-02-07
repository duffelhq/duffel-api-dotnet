using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class OrderChangeRequests
    {
        private readonly HttpClient _httpClient;

        public OrderChangeRequests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Create(OrderChangeRequest request)
        {
            var payload = OrderChangeConverter.Serialize(request);

        }
    }
}