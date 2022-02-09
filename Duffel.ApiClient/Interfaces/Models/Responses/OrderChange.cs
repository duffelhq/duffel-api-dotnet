using System;
using Duffel.ApiClient.Interfaces.Models.Responses.OrderChanges;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class OrderChange
    {
        /// <summary>
        /// The amount that will be charged or refunded, determined according to the fare conditions. A negative value will reflect a refund.
        /// </summary>
        [JsonProperty("change_total_amount")]
        public string ChangeTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the change_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("change_total_currency")]
        public string ChangeTotalCurrency { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime that indicates when the order change was confirmed
        /// </summary>
        [JsonProperty("confirmed_at")]
        public DateTime? ConfirmedAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the order change was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime by which this change must be confirmed
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the order change
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Whether the order change was created in live mode. This field will be set to true if the order change was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public bool IsLiveMode { get; set; }
        
        /// <summary>
        /// The total price of the order for all the flights and services booked, including taxes, once the change is confirmed.
        /// </summary>
        [JsonProperty("new_total_amount")]
        public string NewTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the new_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("new_total_currency")]
        public string NewTotalCurrency { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the order which is being changed
        /// </summary>
        /// <example>ord_0000A3tQcCRZ9R8OY0QlxA</example>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        
        /// <summary>
        /// The amount charged by the airline for making this change.
        /// </summary>
        [JsonProperty("penalty_total_amount")]
        public string PenaltyTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the penalty_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("penalty_total_currency")]
        public string PenaltyTotalCurrency { get; set; }
        
        /// <summary>
        /// Where the refund, once confirmed, will be sent. Refunds are indicated by a negative change_total_amount. If the change does not require a refund, this field will be null. original_form_of_payment refers to the form of payment used to create the order.
        /// </summary>
        /// <example>Possible values: "voucher" or "original_form_of_payment"</example>
        [JsonProperty("refund_to")]
        public string RefundTo { get; set; }
        
        /// <summary>
        /// The slices within an order change that are being added to and/or removed from the order
        /// </summary>
        [JsonProperty("slices")]
        public Slices Slices { get; set; }
    }
}