using Duffel.ApiClient.Converters.Json;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class ChangeSlice : Slice
    {
        [JsonProperty("cabin_class")]
        [JsonConverter(typeof(CabinClassJsonConverter))]
        public CabinClass CabinClass { get; set; }
    }
}