using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class OffersRequest
    {
        [JsonProperty(PropertyName = "passengers")]
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();

        [JsonProperty(PropertyName = "slices")]
        public List<Requests.Slice> Slices { get; set; } = new List<Requests.Slice>();

        [JsonProperty(PropertyName = "requested_sources")]
        public List<string> RequestedSources { get; set; } = new List<string>();
    }
}