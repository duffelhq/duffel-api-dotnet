using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class OrderMetadata
    {
        /// <summary>
        /// Metadata contains a set of key-value pairs that you can attach to an object. It can be useful for storing additional information about the object, in a structured format. Duffel does not use this information. You should not store sensitive information in this field.
        /// The metadata is a collection of key-value pairs, both of which are strings. You can store a maximum of 50 key-value pairs, where each key has a maximum length of 40 characters and each value has a maximum length of 500 characters.
        /// Keys must only contain numbers, letters, dashes, or underscores.
        /// Tp clear metadata supply empty dictionary
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }
}