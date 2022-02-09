using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses.Offers
{
    public class BaggageAllowance
    {
        /// <summary>
        /// The number of this type of bag allowed on the segment.
        /// Note that this can currently be 0 in some cases.
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// The type of the baggage allowance. Possible values defined in <see cref="BaggageType"/>
        /// </summary>
        [JsonProperty("type")]
        public BaggageType BaggageType { get; set; }
    }
}