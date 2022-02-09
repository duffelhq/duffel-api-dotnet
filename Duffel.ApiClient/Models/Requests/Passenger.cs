using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class Passenger
    {
        [JsonProperty("type")]
        public PassengerType PassengerType { get; set; }
    }
}