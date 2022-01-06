using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    /// <summary>
    /// Duffel payloads for requests and responses are hidden behind
    /// the DATA property. This wrapper help to handle this fact, so
    /// the code does not need to handle it in multiple places
    /// </summary>
    /// <typeparam name="T">Type of the object that resides inside DATA property</typeparam>
    internal class DuffelDataWrapper<T> where T: class
    {
        public DuffelDataWrapper(T request)
        {
            Data = request;
        }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public T Data { get; set; }
    }
}