using System;
using Newtonsoft.Json;
using PlaceJsonConverter = Duffel.ApiClient.Converters.Json.PlaceJsonConverter;

namespace Duffel.ApiClient.Models.Responses
{
    public class Slice
    {
        /// <summary>
        /// The <see cref="City"/> or <see cref="Airport"/> the passengers want to depart from
        /// </summary>
        [JsonProperty("origin")]
        [JsonConverter(typeof(PlaceJsonConverter))]
        public Place Origin { get; set; }
        
        /// <summary>
        /// The <see cref="City"/> or <see cref="Airport"/> the passengers want to travel to
        /// </summary>
        [JsonProperty("destination")]
        [JsonConverter(typeof(PlaceJsonConverter))]
        public Place Destination { get; set; }
        
        /// <summary>
        /// The ISO 8601 date on which the passengers want to depart
        /// </summary>
        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}