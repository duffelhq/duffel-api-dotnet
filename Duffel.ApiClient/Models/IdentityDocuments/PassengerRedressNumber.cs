namespace Duffel.ApiClient.Models.IdentityDocuments
{
    using Newtonsoft.Json;

    public class PassengerRedressNumber : IdentityDocument
    {
        /// <summary>
        /// The ISO 3166-1 alpha-2 code of the country that issued this identity document
        /// </summary>
        [JsonProperty("issuing_country_code")]
        public string IssuingCountryCode { get; set; }

        /// <summary>
        /// The unique identifier of the identity document. e.g. the passenger redress number.
        /// </summary>
        [JsonProperty("unique_identifier")]
        public string UniqueIdentifier { get; set; }

    }
}