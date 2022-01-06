using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Passenger
    {
        [JsonProperty("type")]
        public PassengerType PassengerType { get; set; }
    }
}