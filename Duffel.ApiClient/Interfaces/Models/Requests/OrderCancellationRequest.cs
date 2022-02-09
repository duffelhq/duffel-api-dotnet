using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class OrderCancellationRequest
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        
    }
}