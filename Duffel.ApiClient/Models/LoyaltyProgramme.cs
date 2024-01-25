namespace Duffel.ApiClient.Models
{
    using Newtonsoft.Json;

    public class LoyaltyProgramme
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("alliance")]
        public string Alliance { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_airline_id")]
        public string OwnerAirlineId { get; set; }
    }
}
