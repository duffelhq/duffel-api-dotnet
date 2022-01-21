using System;
using Duffel.ApiClient.Converters;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses.Offers
{
    public class Slice
    {
        /// <summary>
        /// The conditions associated with this slice, describing the kinds of modifications you can make post-booking and any penalties that will apply to those modifications.
        /// This condition is applied only to this slice and to all the passengers associated with this offer.
        /// If a particular kind of modification is allowed, you may not always be able to take action through the Duffel API.
        /// In some cases, you may need to contact the Duffel support team or the airline directly.
        /// </summary>
        [JsonProperty("conditions")]
        public Conditions Conditions { get; set; }
        
        /// <summary>
        /// The <see cref="City"/> or <see cref="Airport"/> where this slice begins.
        /// </summary>
        [JsonProperty("origin")]
        [JsonConverter(typeof(PlaceJsonConverter))]
        public Place Origin { get; set; }
        
        /// <summary>
        /// The <see cref="City"/> or <see cref="Airport"/> where this slice ends.
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
        /// The name of the fare brand associated with this slice.
        /// A fare brand specifies the travel conditions you get on your slice made available by the airline.
        /// e.g. a British Airways Economy Basic fare will only include a hand baggage allowance.
        /// It is worth noting that the fare brand names are defined by the airlines themselves and therefore
        /// they are subject to change without any prior notice.
        /// We’re in the process of adding support for fare_brand_name across all our airlines,
        /// so for now, this field may be null in some offers. This will become a non-nullable attribute in the near future.
        /// </summary>
        [JsonProperty("fare_brand_name")]
        public string FareBrandName { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the slice. It identifies the slice of an offer
        /// (i.e. the same slice across offers will have different ids.)
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        // TODO: Segments
        
    }
}