using System.Collections.Generic;
using System.ComponentModel;
using Duffel.ApiClient.Converters;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
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
    }
}