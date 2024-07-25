namespace Duffel.ApiClient.Models
{
    using Newtonsoft.Json;

    public class LoyaltyProgramme
    {
        /// <summary>
        /// Duffel's unique identifier for the loyalty programme.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the alliance this loyalty programme is part of.
        /// </summary>
        [JsonProperty("alliance")]
        public string Alliance { get; set; }

        /// <summary>
        /// Name of the loyalty programme.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The Duffel ID of the airline that corresponds to the loyalty programme.
        /// </summary>
        [JsonProperty("owner_airline_id")]
        public string OwnerAirlineId { get; set; }

        /// <summary>
        /// Path to a svg of the loyalty programme logo. This may be null if no logo is available.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
    }
}
