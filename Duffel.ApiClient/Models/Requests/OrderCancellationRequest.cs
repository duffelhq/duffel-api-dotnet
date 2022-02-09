using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class OrderCancellationRequest
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        
    }
}