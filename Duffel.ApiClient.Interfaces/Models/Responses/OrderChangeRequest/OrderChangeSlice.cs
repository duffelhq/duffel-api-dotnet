using System;
using System.Collections.Generic;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models.Responses.Offers;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses.OrderChangeRequest
{
    public class OrderChangeSlice
    {
        /// <summary>
        /// The city or airport where this slice ends
        /// </summary>
        [JsonProperty("destination")]
        [JsonConverter(typeof(PlaceJsonConverter))]
        public Place Destination { get; set; }
        
        /// <summary>
        /// The duration of the slice, represented as a ISO 8601 duration
        /// </summary>
        [JsonProperty("duration")]
        [JsonConverter(typeof(StringDurationToTimeStampJsonConverter))]
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the slice. It identifies the slice of an order (i.e. the same slice across orders will have different ids.
        /// </summary>
        /// <example>sli_00009htYpSCXrwaB9Dn123</example>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The city or airport where this slice begins
        /// </summary>
        [JsonProperty("origin")]
        [JsonConverter(typeof(PlaceJsonConverter))]
        public Place Origin { get; set; }
        
        /// <summary>
        /// The segments - that is, specific flights - that the airline is offering to get the passengers from the origin to the destination
        /// </summary>
        [JsonProperty("segments")]
        public IEnumerable<Segment> Segments { get; set; }

    }
}