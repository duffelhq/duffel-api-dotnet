using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public class LoyaltyProgrammeAccount
    {
        /// <summary>
        /// The passenger's account number for a particular Loyalty Programme Account
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// The IATA code for the airline that a particular Loyalty Programme Account belongs to
        /// </summary>
        [JsonProperty("airline_iata_code")]
        public string AirlineIataCode { get; set; }
    }
}