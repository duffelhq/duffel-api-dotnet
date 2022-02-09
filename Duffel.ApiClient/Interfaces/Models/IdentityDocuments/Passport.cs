using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.IdentityDocuments
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
        /// The type of the identity document. Currently, the only supported type is passport. This must be one of the allowed_passenger_identity_document_types on the offer.
        /// </summary>
        [JsonProperty("unique_identifier")]
        public string UniqueIdentifier { get; set; } 
        
    }
}