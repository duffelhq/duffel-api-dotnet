using Duffel.ApiClient.Converters;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class ChangeSlice : Slice
    {
        [JsonProperty("cabin_class")]
        [JsonConverter(typeof(CabinClassJsonConverter))]
        public CabinClass CabinClass { get; set; }
    }
}