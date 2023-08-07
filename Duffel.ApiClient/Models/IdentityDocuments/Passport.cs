using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.IdentityDocuments
{
    public class Passport : IdentityDocument
    {
        /// <summary>
        /// The date on which the identity document expires
        /// </summary>
        [JsonProperty("expires_on")]
        public string ExpiresOn { get; set; }

        /// <summary>
        /// The ISO 3166-1 alpha-2 code of the country that issued this identity document
        /// </summary>
        [JsonProperty("issuing_country_code")]
        public string IssuingCountryCode { get; set; }

        /// <summary>
        /// The unique identifier of the identity document. e.g. the passport number.
        /// </summary>
        [JsonProperty("unique_identifier")]
        public string UniqueIdentifier { get; set; }

    }
}
