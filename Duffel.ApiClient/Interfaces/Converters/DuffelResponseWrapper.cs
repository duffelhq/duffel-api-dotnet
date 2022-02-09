using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Converters
{
    internal class DuffelResponseWrapper<T> : DuffelDataWrapper<T> where T: class
    {
        public DuffelResponseWrapper(T request) : base(request)
        {
        }
        
        [JsonProperty("meta")]
        public Metadata Metadata { get; set; }
        
        [JsonProperty("errors")]
        public IEnumerable<Error> Errors { get; set; }
    }
}