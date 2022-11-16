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
        
        /// <summary>
        /// URL to the airline's conditions of carriage.
        /// Can be null.
        /// </summary>
        [JsonProperty("conditions_of_carriage_url")]
        public string ConditionsOfCarriageUrl { get; set; }

        /// <summary>
        /// Path to a svg of the airline lockup logo. A lockup logo is also called a combination logo, in which it combines the logotype and logomark.
        /// This may be null if no logo is available.
        /// </summary>
        [JsonProperty("logo_lockup_url")]
        public string LogoLockupUrl { get; set; }

        /// <summary>
        /// Path to a svg of the airline logo. This may be null if no logo is available.
        /// </summary>
        [JsonProperty("logo_symbol_url")]
        public string LogoSymbolUrl { get; set; }
    }
}
