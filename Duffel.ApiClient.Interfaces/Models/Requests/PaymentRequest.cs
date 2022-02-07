using Duffel.ApiClient.Interfaces.Converters;
using Duffel.ApiClient.Interfaces.Models.Payments;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class PaymentRequest
    {
        [JsonConverter(typeof(PaymentJsonConverter))]
        [JsonProperty("payment")]
        public Payment Payment { get; set; }
        
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }
}