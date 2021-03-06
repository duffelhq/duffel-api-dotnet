using System;
using Duffel.ApiClient.Models.Payments;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    //[JsonConverter(typeof(PaymentResponseJsonConverter))]
    public class PaymentResponse : Payment
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("live_mode")]
        public bool IsLiveMode { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("type")]
        public string PaymentType { get; set; }
    }
}