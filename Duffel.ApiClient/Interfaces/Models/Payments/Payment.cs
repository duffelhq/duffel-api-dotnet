using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Payments
{
    public abstract class Payment
    {
        /// <summary>
        /// The amount of the payment. This should be the same as the total_amount of the offer specified in selected_offers, plus the total_amount of all the services specified in services.
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
        
        /// <summary>
        /// The currency of the amount, as an ISO 4217 currency code. This should be the same as the total_currency of the offer specified in selected_offers.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }        
    }
}