using System;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class PaymentRequirements
    {
        /// <summary>
        /// When payment is required at the time of booking this will be true and <see cref="PaymentRequiredBy"/> and <see cref="PriceGuaranteeExpiresAt"/> will be null.
        /// When payment can be made at a time after booking, this will be false and the time limits on the payment will be provided in <see cref="PaymentRequiredBy"/> and <see cref="PriceGuaranteeExpiresAt"/>.
        /// </summary>
        [JsonProperty("requires_instant_payment")]
        public bool RequiresInstantPayment { get; set; }
        
        /// <summary>
        /// Datetime at which the price associated with the order will no longer be guaranteed by the airline and may change before payment.
        /// This will be null when <see cref="RequiresInstantPayment"/> is true.
        /// </summary>
        [JsonProperty("price_guarantee_expires_at")]
        public DateTime? PriceGuaranteeExpiresAt { get; set; }
        
        /// <summary>
        /// Datetime by which you must pay for this offer. At this time, if still unpaid, the reserved space on the flight(s) will be released and you will have to create a new order.
        /// This will be null when the offer requires immediate payment - that is, when <see cref="RequiresInstantPayment"/> is true.
        /// </summary>
        [JsonProperty("payment_required_by")]
        public DateTime? PaymentRequiredBy { get; set; }
    }
}