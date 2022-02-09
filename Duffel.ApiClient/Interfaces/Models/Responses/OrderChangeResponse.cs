using System;
using Duffel.ApiClient.Interfaces.Models.Responses.OrderChangeRequest;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class OrderChangeResponse
    {
        /// <summary>
        /// The ISO 8601 datetime at which the order change request was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The ID of your order change request
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Whether the order was created in live mode. This field will be set to true if the order was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public string IsLiveMode { get; set; }
        
        // OrderChangeOggers list
        
        /// <summary>
        /// The order ID that you want to change
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        
        // slices // add // remove
        
        /// <summary>
        /// The ISO 8601 datetime at which the order change request was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        
    }

    public class OrderChangeOffer
    {
        /// <summary>
        /// The amount that will be charged or returned to the original payment method if refunded, determined according to the fare conditions. This may be negative to reflect a refund.
        /// </summary>
        [JsonProperty("change_total_amount")]
        public string ChangeTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the change_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("change_total_currency")]
        public string ChangeTotalCurrency { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the offer was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the offer will expire and no longer be usable to create an order
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the order change offer
        /// </summary>
        /// <example>oco_0000A3vUda8dKRtUSQPSXw</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Whether the order change offer was created in live mode. This field will be set to true if the order change offer was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public bool IsLiveMode { get; set; }
        
        /// <summary>
        /// The price of this offer if it was newly purchased
        /// </summary>
        [JsonProperty("new_total_amount")]
        public string NewTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the new_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("new_total_currency")]
        public string NewTotalCurrency { get; set; }
        
        /// <summary>
        /// The ID for an order change if one has already been created from this order change offer
        /// </summary>
        /// <example>oce_0000A4QasEUIjJ6jHKfhHU</example>
        [JsonProperty("order_change_id")]
        public string OrderChangeId { get; set; }
        
        /// <summary>
        /// The penalty imposed by the airline for making this change
        /// </summary>
        [JsonProperty("penalty_total_amount")]
        public string PenaltyTotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the penalty_total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("penalty_total_currency")]
        public string PenaltyTotalCurrency { get; set; }

        /// <summary>
        /// Where the refund, once confirmed, will be sent. card is currently a restricted feature. awaiting_payment is for pay later orders where no payment has been made yet.
        /// </summary>
        /// <example>Possible values: "arc_bsp_cash", "balance", "card", "voucher", or "awaiting_payment"</example>
        [JsonProperty("refund_to")]
        public string RefundTo { get; set; }
        
        /// <summary>
        /// The slices within an order change that are being added to and/or removed from the order
        /// </summary>
        [JsonProperty("slices")]
        public Slices Slices { get; set; }

        /// <summary>
        /// The ISO 8601 datetime at which the offer was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
    }
}