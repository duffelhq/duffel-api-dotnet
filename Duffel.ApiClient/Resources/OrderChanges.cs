using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Payments;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Resources
{
    public class OrderChanges
    {
        private readonly HttpClient _httpClient;

        public OrderChanges(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderChange> CreatePending(string orderChangeRequestId, string selectedOfferId)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var payload =  JsonConvert.SerializeObject(
                new DuffelDataWrapper<SelectedOrderChangeOffer>(
                    new SelectedOrderChangeOffer { Id = selectedOfferId }), Formatting.None, settings);

            var result = await _httpClient.PostAsync($"air/order_changes/{orderChangeRequestId}",
                new StringContent(payload, Encoding.UTF8, "application/json"));

            return await SingleItemResponseConverter.GetAndDeserialize<OrderChange>(result);
        }

        public async Task<OrderChange> Get(string orderChangeId)
        {
            var result = await _httpClient.GetAsync($"air/order_changes/{orderChangeId}");
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChange>(result);
        }
        
        public async Task<OrderChange> ConfirmPending(string orderChangeId, Payment payment)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var content = JsonConvert.SerializeObject(new DuffelDataWrapper<Payment>(payment), Formatting.None, settings);
            
            var result = await _httpClient.PostAsync($"air/order_changes/{orderChangeId}/actions/confirm", 
                new StringContent(content,  Encoding.UTF8, "application/json"));

            return await SingleItemResponseConverter.GetAndDeserialize<OrderChange>(result);
        }
    }
}