using Duffel.ApiClient.Interfaces.Models.Payments;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class ConfirmOrderChangeRequest
    {
        /// <summary>
        /// Duffel's unique identifier for the order change
        /// </summary>
        /// <example>ocr_0000A3tQSmKyqOrcySrGbo</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The payment details to use to pay for the order change, if there is an amount to be paid.
        /// Some order changes may not need this. If the change_total_amount is zero or negative, there is no need to pass a payment object.
        /// </summary>
        [JsonProperty(PropertyName = "payment", NullValueHandling = NullValueHandling.Ignore)]
        public Payment Payment { get; set; }
    }
}