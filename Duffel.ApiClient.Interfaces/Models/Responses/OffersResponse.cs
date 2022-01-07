using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class OffersResponse
    {
        /// <summary>
        /// The slices that make up this offer request. One-way journeys can be expressed using one slice, whereas return trips will need two.
        /// </summary>
        [JsonProperty("slices")]
        public IEnumerable<Slice>? Slices { get; set; }
        
        /// <summary>
        /// The offers returned by the airlines
        /// </summary>
        [JsonProperty("offers")]
        public IEnumerable<Offer>? Offers { get; set; }
        
        // TODO: passengers, live_mode
    }
}