using System;
using System.Collections.Generic;
using Duffel.ApiClient.Converters.Json;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class OffersResponse
    {
        /// <summary>
        /// The slices that make up this offer request. One-way journeys can be expressed using one slice, whereas return trips will need two.
        /// </summary>
        [JsonProperty("slices")]
        public IEnumerable<Slice> Slices { get; set; }
        
        /// <summary>
        /// The offers returned by the airlines
        /// </summary>
        [JsonProperty("offers")]
        public IEnumerable<Offer> Offers { get; set; }
        
        /// <summary>
        /// The passengers who want to travel
        /// </summary>
        [JsonProperty("passengers")]
        public IEnumerable<Passenger> Passengers { get; set; }
        
        /// <summary>
        /// Whether the offer request was created in live mode.
        /// This field will be set to true if the offer request was created in live mode, or false if it was created in test mode
        /// </summary>
        [JsonProperty("live_mode")]
        public bool IsLiveMode { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the offer request
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The datetime at which the offer request was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("cabin_class")]
        [JsonConverter(typeof(CabinClassJsonConverter))]
        public CabinClass CabinClass { get; set; }
    }
}