using Newtonsoft.Json;

namespace Duffel.ApiClient.Models
{
    public class Passenger
    {
        [JsonProperty("type")]
        public PassengerType PassengerType { get; set; }
    }
}