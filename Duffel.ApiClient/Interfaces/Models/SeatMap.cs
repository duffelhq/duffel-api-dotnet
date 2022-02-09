using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class SeatMap
    {
        /// <summary>
        /// The list of cabins in this seat map.
        /// Cabins are ordered by deck from lowest to highest, and then within each deck from the front to back of the aircraft.
        /// </summary>
        [JsonProperty("cabins")]
        public IEnumerable<Cabin> Cabins { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the seat map
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the segment. It identifies the segment of an offer (i.e. the same segment across offers will have different ids).
        /// </summary>
        [JsonProperty("segment_id")]
        public string SegmentId { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the slice. It identifies the slice of an offer (i.e. the same slice across offers will have different ids.) 
        /// </summary>
        [JsonProperty("slice_id")]
        public string SliceId { get; set; }
    }
}