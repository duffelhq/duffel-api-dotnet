using System;
using System.Collections.Generic;
using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class Order
    {
        /// <summary>
        /// The base price of the order for all flights and services booked, excluding taxes
        /// </summary>
        /// <example>"30.20"</example>
        [JsonProperty("base_amount")]
        public string BaseAmount { get; set; }
        
        /// <summary>
        /// The currency of the base_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }
        
        /// <summary>
        /// The airline's reference for the order, sometimes known as a "passenger name record" (PNR) or "record locator". Your customers can use this to check in and manage their booking on the airline's website. Usually, this is made up of six alphanumeric characters, but airlines can have their own formats (for example, easyJet's booking references are 7 alphanumeric characters long and LATAM's references are made up of 13 alphanumeric characters beginning with LA.)
        /// </summary>
        /// <example>"RZPNX8"</example>
        [JsonProperty("booking_reference")]
        public string BookingReference { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the order was cancelled, if it has been cancelled
        /// </summary>
        /// <example>"2020-04-11T15:48:11.642Z"</example>
        [JsonProperty("cancelled_at")]
        public DateTime? CancelledAt { get; set; }
        
        /// <summary>
        /// The conditions associated with this order, describing the kinds of modifications you can make to it and any penalties that will apply to those modifications. This information assumes the condition is applied to all of the slices and passengers associated with this order - for information at the slice level (e.g. "what happens if I just want to change the first slice?") refer to the slices. If a particular kind of modification is allowed, you may not always be able to take action through the Duffel API. In some cases, you may need to contact the Duffel support team or the airline directly.
        /// </summary>
        [JsonProperty("conditions")]
        public Conditions Conditions { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the order was created
        /// </summary>
        /// <example>"2020-04-11T15:48:11.642Z"</example>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// The documents issued for this order
        /// </summary>
        [JsonProperty("documents")]
        public IEnumerable<Document> Documents { get; set; }

        /// <summary>
        /// Duffel's unique identifier for the order
        /// </summary>
        /// <example>"ord_00009hthhsUZ8W4LxQgkjo"</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Whether the order was created in live mode. This field will be set to true if the order was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public string IsLiveMode { get; set; }
        
        /// <summary>
        /// Metadata contains a set of key-value pairs that you can attach to an object. It can be useful for storing additional information about the object, in a structured format. Duffel does not use this information. You should not store sensitive information in this field.
        /// </summary>
        /// <example>{"customer_prefs":"window seat","payment_intent_id":"pit_00009htYpSCXrwaB9DnUm2"}</example>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; set; }
        
        /// <summary>
        /// The airline who owns the order
        /// </summary>
        [JsonProperty("airline")]
        public Airline Owner { get; set; }
        
        /// <summary>
        /// The passengers who are travelling
        /// </summary>
        [JsonProperty("passengers")]
        public IEnumerable<OrderPassenger> Passengers { get; set; }
        
        /// <summary>
        /// The payment status for this order
        /// </summary>
        [JsonProperty("payment_status")]
        public PaymentStatus PaymentStatus { get; set; }
        
        /// <summary>
        /// The services booked along with this order
        /// </summary>
        [JsonProperty("services")]
        public  IEnumerable<Service> Services { get; set; }
        
        /// <summary>
        /// The slices that make up the itinerary of this order. One-way journeys can be expressed using one slice, whereas return trips will need two.
        /// </summary>
        [JsonProperty("slices")]
        public IEnumerable<Orders.Slice> Slices { get; set; }
        
        /// <summary>
        /// Airlines are always the source of truth for orders. The orders returned in the Duffel API are a view of those orders. This field is the ISO 8601 datetime at which the Order was last synced with the airline. If this datetime is in the last minute you can consider the order up to date.
        /// </summary>
        [JsonProperty("synced_at")]
        public DateTime SyncedAt { get; set; }
        
        /// <summary>
        /// The amount of tax payable on the order for all the flights booked
        /// </summary>
        [JsonProperty("tax_amount")]
        public string TaxAmount { get; set; }
        
        /// <summary>
        /// The currency of the tax_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("tax_currency")]
        public string TaxCurrency { get; set; }
        
        /// <summary>
        /// The total price of the order for all the flights and services booked, including taxes
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