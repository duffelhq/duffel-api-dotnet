using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    internal class Metadata
    {
        [JsonProperty(PropertyName = "limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
        
        [JsonProperty(PropertyName = "before", NullValueHandling = NullValueHandling.Ignore)]
        public string Before { get; set; }
        
        [JsonProperty(PropertyName = "after", NullValueHandling = NullValueHandling.Ignore)]
        public string After { get; set; }
        
    }
}