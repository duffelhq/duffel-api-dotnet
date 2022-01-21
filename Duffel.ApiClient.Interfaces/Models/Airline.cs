using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Airline
    {
        [JsonProperty("name")]
        public string AirlineName { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("iata_code")]
        public string IataCode { get; set; }
    }
}