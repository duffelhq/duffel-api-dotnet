using Duffel.ApiClient.Converters;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses.Offers
{
    public class SegmentPassenger
    {
        /// <summary>
        /// The identifier for the passenger.
        /// You may have specified this ID yourself when creating the offer request, or otherwise, Duffel will have generated its own random ID.
        /// </summary>
        [JsonProperty("passenger_id")]
        public string PassengerId { get; set; }
        
        /// <summary>
        /// The airline's alphanumeric code for the fare that the passenger is using to travel.
        /// Where this is null, it means that either the fare basis code is not available or the airline does not use fare basis codes.
        /// </summary>
        [JsonProperty("fare_basis_code")]
        public string FareBasisCode { get; set; }
        
        /// <summary>
        /// The name that the marketing carrier uses to market this cabin class
        /// </summary>
        /// <example>"Economy Basic"</example>
        [JsonProperty("cabin_class_marketing_name")]
        public string CabinClassMarketingName { get; set; }
        
        /// <summary>
        /// The cabin class that the passenger will travel in on this segment
        /// Possible values: "first", "business", "premium_economy", or "economy"
        /// </summary>
        [JsonProperty("cabin_class")]
        [JsonConverter(typeof(CabinClassJsonConverter))]
        public CabinClass CabinClass { get; set; }
        
        // TODO: baggages
    }
}