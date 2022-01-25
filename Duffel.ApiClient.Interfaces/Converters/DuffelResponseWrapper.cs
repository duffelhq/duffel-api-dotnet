using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    internal class DuffelResponseWrapper<T> : DuffelDataWrapper<T> where T: class
    {
        public DuffelResponseWrapper(T request) : base(request)
        {
        }
        
        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }
    }
}