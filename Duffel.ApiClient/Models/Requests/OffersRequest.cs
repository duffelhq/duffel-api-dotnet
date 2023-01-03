using System.Collections.Generic;
using Duffel.ApiClient.Converters.Json;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class OffersRequest
    {
        [JsonProperty("passengers")]
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();

        [JsonProperty("slices")]
        public List<Slice> Slices { get; set; } = new List<Slice>();

        [JsonProperty("requested_sources")]
        public List<string> RequestedSources { get; set; } = new List<string>();
        
        /// <summary>
        /// The cabin that the passengers want to travel in
        /// </summary>
        [JsonProperty(
            PropertyName = "cabin_class", 
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(CabinClassJsonConverter))]
        public CabinClass CabinClass { get; set; }
        
        /// <summary>
        /// The maximum number of connections within any slice of the offer.
        /// For example 0 means a direct flight which will have a single segment within each slice
        /// and 1 means a maximum of two segments within each slice of the offer.        
        /// </summary>
        [JsonProperty("max_connections")]
        public int MaxConnections { get; set; } = 1;
    }
}
