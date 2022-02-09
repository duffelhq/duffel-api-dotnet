using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses
{
    public class Passenger
    {
        /// <summary>
        /// The age of the passenger on the departure_date of the final slice
        /// </summary>
        [JsonProperty("age")]
        public int? Age { get; set; }
        
        /// <summary>
        /// The passenger's family name. Only space, -, ', and letters from the ASCII, Latin-1 Supplement and Latin Extended-A (with the exceptions of Æ, æ, Ĳ, ĳ, Œ, œ, Þ, and ð) Unicode charts are accepted. All other characters will result in a validation error.
        /// The minimum length is 1 character, and the maximum is 20 characters.
        /// This is only required if you're also including Loyalty Programme Accounts.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        
        /// <summary>
        /// The passenger's given name. Only space, -, ', and letters from the ASCII, Latin-1 Supplement and Latin Extended-A (with the exceptions of Æ, æ, Ĳ, ĳ, Œ, œ, Þ, and ð) Unicode charts are accepted. All other characters will result in a validation error.
        /// The minimum length is 1 character, and the maximum is 20 characters.
        /// This is only required if you're also including Loyalty Programme Accounts.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        
        /// <summary>
        /// The type of the passenger
        /// </summary>
        [JsonProperty("type")]
        public PassengerType PassengerType { get; set; }
        
        /// <summary>
        /// The Loyalty Programme Accounts for this passenger
        /// </summary>
        [JsonProperty("loyalty_programme_accounts")]
        public IEnumerable<LoyaltyProgrammeAccount> LoyaltyProgrammeAccounts { get; set; } 
        
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}