namespace Duffel.ApiClient.Models.IdentityDocuments
{
    using Newtonsoft.Json;

    public class TaxId : IdentityDocument
    {
        /// <summary>
        /// The unique identifier of the identity document. e.g. the tax id.
        /// </summary>
        [JsonProperty("unique_identifier")]
        public string UniqueIdentifier { get; set; }

    }
}