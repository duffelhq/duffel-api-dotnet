using System;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class PaymentStatus
    {
        /// <summary>
        /// Whether a full payment has been made, or the airline is waiting for a payment to be made. This will be set to false if the order has been cancelled or if payment_required_by has elapsed.
        /// </summary>
        [JsonProperty("awaiting_payment")]
        public bool AwaitingPayment { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime by which you must pay for this order. At this time, if still unpaid, the reserved space on the flight(s) will be released and you will have to create a new order. This will be null only for orders where awaiting_payment is false.
        /// </summary>
        [JsonProperty("payment_required_by")]
        public DateTime? PaymentRequiredBy { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the price associated with the order will no longer be guaranteed by the airline and the order will need to be repriced before payment. This will be null when there is no price guarantee.
        /// </summary>
        [JsonProperty("price_guarantee_expires_at")]
        public DateTime? PriceGuaranteeExpiresAt { get; set; }
    }
}