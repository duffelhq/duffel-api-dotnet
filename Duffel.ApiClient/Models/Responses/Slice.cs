using System;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class Slice
    {

        [JsonProperty("origin")]
        public Place Origin { get; set; }
        
        [JsonProperty("destination")]
        public Place Destination { get; set; }
        
        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}