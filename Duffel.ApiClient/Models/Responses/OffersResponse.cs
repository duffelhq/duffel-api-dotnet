using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class OffersResponse
    {
        [JsonProperty("slices")]
        public IEnumerable<Responses.Slice> Slices { get; set; }
    }
}