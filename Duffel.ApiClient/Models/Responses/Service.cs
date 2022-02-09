using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class Service
    {
        /// <summary>
        /// Duffel's unique identifier for the service
        /// </summary>
        /// <example>ase_00009UhD4ongolulWd9123</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The maximum quantity of this service that can be booked with an order
        /// </summary>
        [JsonProperty("maximum_quantity")]
        public int MaximumQuantity { get; set; }
        
        /// <summary>
        /// An object containing metadata about the service, like the maximum weight and dimensions of the baggage.
        /// </summary>
        [JsonProperty("metadata")]
        public BaggageMetadata Metadata { get; set; }
        
        /// <summary>
        /// The list of passenger ids the service applies to. If you add this service to an order it will apply to all the passengers in this list. For services where the type is baggage, this list will include only a single passenger.
        /// </summary>
        [JsonProperty("passenger_ids")]
        public IEnumerable<string> PassengerIds { get; set; }
        
        /// <summary>
        /// The list of segment ids the service applies to. If you add this service to an order it will apply to all the segments in this list. For services where the type is baggage, depending on the airline, this list includes all the segments of all slices or all the segments of a single slice.
        /// </summary>
        [JsonProperty("segment_ids")]
        public IEnumerable<string> SegmentIds { get; set; }
        
        /// <summary>
        /// The total price of the service for all passengers and segments it applies to, including taxes. This price is for a single unit of the service. 
        /// </summary>
        [JsonProperty("total_amount")]
        public string TotalAmount { get; set; }
        
        /// <summary>
        /// The currency of the total_amount, as an ISO 4217 currency code. It will match your organisation's billing currency unless you’re using Duffel as an accredited IATA agent, in which case it will be in the currency provided by the airline (which will usually be based on the country where your IATA agency is registered).
        /// </summary>
        [JsonProperty("total_currency")]
        public string TotalCurrency { get; set; }
        
        /// <summary>
        /// The type of the service. For now we only return services of type baggage but we will return other types in the future. We won't consider adding new service types a breaking change.
        /// </summary>
        [JsonProperty("type")]
        public string ServiceType { get; set; }
    }
    
    public class BaggageMetadata
    {
        /// <summary>
        /// The maximum depth that the baggage can have in centimetres
        /// </summary>
        [JsonProperty("maximum_depth_cm")]
        public int? MaximumDepthCm { get; set; }
        
        /// <summary>
        /// The maximum height that the baggage can have in centimetres
        /// </summary>
        [JsonProperty("maximum_height_cm")]
        public int? MaximumHeightCm { get; set; }
        
        /// <summary>
        /// The maximum length that the baggage can have in centimetres
        /// </summary>
        [JsonProperty("maximum_length_cm")]
        public int? MaximumLengthCm { get; set; }
        
        /// <summary>
        /// The maximum weight that the baggage can have in kilogram
        /// </summary>
        [JsonProperty("maximum_weight_kg")]
        public int? MaximumWeightKg { get; set; }
        
        /// <summary>
        /// The type of the baggage
        /// Possible values: "checked" or "carry_on"
        /// </summary>
        [JsonProperty("type")]
        public string BaggageType { get; set; }
    }
}