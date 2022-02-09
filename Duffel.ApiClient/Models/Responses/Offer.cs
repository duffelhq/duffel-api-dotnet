using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    /// <summary>
    /// An offer represents flights you can buy from an airline at a particular price that meet your search criteria.
    /// </summary>
    public class Offer
    {
        /// <summary>
        /// The ISO 8601 datetime at which the offer was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        /// <summary>
        /// An estimate of the total carbon dioxide (CO₂) emissions when all of the passengers fly this offer's itinerary, measured in kilograms
        /// </summary>
        [JsonProperty("total_emissions_kg")]
        public string TotalEmissionsKg { get; set; }
        
        /// <summary>
        /// The currency of the total_amount, as an ISO 4217 currency code.
        /// It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent,
        /// in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("total_currency")]
        public string TotalCurrency { get; set; }
        
        /// <summary>
        /// The total price of the offer for all passengers, including taxes.
        /// It does not include the total price of any service(s) that might be booked with the offer.
        /// </summary>
        [JsonProperty("total_amount")]
        public string TotalAmount { get; set; }
        
        [JsonProperty("tax_currency")]
        public string TaxCurrency { get; set; }
        
        [JsonProperty("tax_amount")]
        public string TaxAmount { get; set; }
        
        /// <summary>
        /// The slices that make up this offer.
        /// Each slice will include one or more segments, the specific flights that the airline is offering to take the passengers from the slice's origin to its destination.
        /// </summary>
        [JsonProperty("slices")]
        public IEnumerable<Offers.Slice> Slices { get; set; }


        /// <summary>
        /// The payment requirements for this offer
        /// </summary>
        [JsonProperty("payment_requirements")]
        public PaymentRequirements PaymentRequirements { get; set; }
        
        // TODO: available services
        
        /// <summary>
        /// The passengers included in the offer
        /// </summary>
        [JsonProperty("passengers")]
        public IEnumerable<Passenger> Passengers { get; set; }

        /// <summary>
        /// Whether identity documents must be provided for each of the passengers when creating an order based on this offer.
        /// If this is true, you must provide an identity document for every passenger.
        /// </summary>
        [JsonProperty("passenger_identity_documents_required")]
        public bool PassengerIdentityDocumentsRequired { get; set; }
        
        /// <summary>
        /// The airline which provided the offer
        /// </summary>
        [JsonProperty("owner")]
        public Airline Owner { get; set; }
        
        /// <summary>
        /// Whether the offer request was created in live mode.
        /// This field will be set to true if the offer request was created in live mode, or false if it was created in test mode.
        /// </summary>
        [JsonProperty("live_mode")]
        public bool LiveMode { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the offer
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the offer will expire and no longer be usable to create an order
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
        
        /// <summary>
        /// The ISO 8601 datetime at which the offer was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        // conditions
        
        /// <summary>
        /// The currency of the <see cref="BaseAmount"/>, as an ISO 4217 currency code.
        /// It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent,
        /// in which case it will be in the currency provided by the airline
        /// (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("base_currency")]
        public string BaseCurrency { get; set; }
        
        /// <summary>
        /// The base price of the offer for all passengers, excluding taxes.
        /// It does not include the base amount of any service(s) that might be booked with the offer.
        /// </summary>
        [JsonProperty("base_amount")]
        public string BaseAmount{ get; set; }
        
        /// <summary>
        /// The types of identity documents that may be provided for the passengers when creating an order based on this offer.
        /// Currently, the only supported type is passport.
        /// If this is empty, then you must not provide identity documents.
        /// </summary>
        [JsonProperty("allowed_passenger_identity_document_types")]
        public IEnumerable<string> AllowedPassengerIdentityDocumentTypes { get; set; }

    }
}