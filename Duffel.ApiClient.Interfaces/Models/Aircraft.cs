using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Aircraft
    {
        /// <summary>
        /// The name of the aircraft
        /// </summary>
        [JsonProperty("name")]
        public string AircraftName { get; set; }
        
        /// <summary>
        /// Duffel's unique identifier for the aircraft
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The three-character IATA code for the aircraft
        /// </summary>
        /// <example>"380"</example>
        [JsonProperty("iata_code")]
        public string IataCode { get; set; }
    }
}