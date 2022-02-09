using System;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class OrderCancellation
    {
        /// <summary>
        /// The ISO 8601 datetime that indicates when the order cancellation was confirmed
        /// </summary>
        [JsonProperty("confirmed_at")]
        public DateTime? ConfirmedAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the order cancellation was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime by which this cancellation must be confirmed
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the order cancellation
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Whether the order cancellation was created in live mode. This field will be set to true if the order cancellation was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public bool IsLiveMode { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the order
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        
        /// <summary>
        /// The amount that will be returned to the original payment method if the order is cancelled, determined according to the fare conditions. This may be 0.00 if the fare is non-refundable. It will include the refund amount of the flights and the services booked.
        /// </summary>
        [JsonProperty("refund_amount")]
        public string RefundAmount { get; set; }
        
        /// <summary>
        /// The currency of the refund_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered). For hold orders that are awaiting payment, the refund amount will always be 0.00.
        /// </summary>
        [JsonProperty("refund_currency")]
        public string RefundCurrency { get; set; }
        
        /// <summary>
        /// Where the refund, once confirmed, will be sent. card is currently a restricted feature. awaiting_payment is for pay later orders where no payment has been made yet.
        /// </summary>
        [JsonProperty("refund_to")]
        public RefundType RefundTo { get; set; }
    }
}