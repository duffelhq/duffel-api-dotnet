using Newtonsoft.Json;

namespace Duffel.ApiClient.Models
{
    public class Airline
    {
        /// <summary>
        /// The name of the airline
        /// </summary>
        [JsonProperty("name")]
        public string AirlineName { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the airline
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The two-character IATA code for the airline. This may be null for non-IATA carriers.
        /// </summary>
        [JsonProperty("iata_code")]
        public string IataCode { get; set; }
    }
}