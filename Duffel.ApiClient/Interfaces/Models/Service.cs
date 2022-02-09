using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Service
    {
        /// <summary>
        /// The id of the service from the offer's available_services that you want to book
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The quantity of the service to book. This will always be 1 for seat services.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}