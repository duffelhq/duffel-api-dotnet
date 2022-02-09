using Duffel.ApiClient.Models.Payments;
using Newtonsoft.Json;
using PaymentJsonConverter = Duffel.ApiClient.Converters.Json.PaymentJsonConverter;

namespace Duffel.ApiClient.Models.Requests
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