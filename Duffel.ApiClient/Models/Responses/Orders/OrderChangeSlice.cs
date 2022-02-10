using System;
using System.Collections.Generic;
using Duffel.ApiClient.Converters.Json;
using Duffel.ApiClient.Models.Responses.Offers;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses.Orders
{
    public class OrderChangeSlice
    {
        /// <summary>
        /// The city or airport where this slice ends
        /// </summary>
        [JsonProperty("destination")]
        public Place Destination { get; set; }
        
        [JsonProperty("duration")]
        [JsonConverter(typeof(StringDurationToTimeStampJsonConverter))]
        public TimeSpan? Duration { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the slice. It identifies the slice of an order (i.e. the same slice across orders will have different ids.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The city or airport where this slice begins
        /// </summary>
        [JsonProperty("origin")]
        public Place Origin { get; set; }
        
        /// <summary>
        /// The segments - that is, specific flights - that the airline is offering to get the passengers from the origin to the destination
        /// </summary>
        [JsonProperty("segments")]
        public IEnumerable<Segment> Segments { get; set; }
    }
}