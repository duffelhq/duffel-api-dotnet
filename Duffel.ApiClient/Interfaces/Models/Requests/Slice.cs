using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class Slice
    {
        [JsonProperty("origin")] 
        public string Origin { get; set; }

        [JsonProperty("destination")] 
        public string Destination { get; set; }

        [JsonProperty("departure_date")] 
        public string DepartureDate { get; set; }
    }
}