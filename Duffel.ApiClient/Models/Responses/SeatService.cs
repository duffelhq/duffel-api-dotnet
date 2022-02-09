using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class SeatService
    {
        /// <summary>
        /// Duffel's unique identifier for the service
        /// </summary>
        /// <example>ase_00009UhD4ongolulWd9123</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The passenger that this seat is for
        /// </summary>
        [JsonProperty("passenger_id")]
        public string PassengerId { get; set; }
        
        /// <summary>
        /// The total price of the seat, including taxes
        /// </summary>
        [JsonProperty("total_amount")]
        public string TotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("total_currency")]
        public string TotalCurrency { get; set; }
    }
}