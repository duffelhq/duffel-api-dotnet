using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class OffersResponse
    {
        [JsonProperty("slices")]
        public IEnumerable<Slice> Slices { get; set; }
    }
}