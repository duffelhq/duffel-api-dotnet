using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Document
    {
        /// <summary>
        /// The type of document
        /// </summary>
        [JsonProperty("type")]
        public DocumentType DocumentType { get; set; }
        
        /// <summary>
        /// The identifier for the document, in the case of electronic tickets this string represents the payment or the entitlement to fly.
        /// </summary>
        [JsonProperty("unique_identifier")]
        public string UId { get; set; }
    }
}