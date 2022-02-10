using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public class Error
    {
        /// <summary>
        /// A machine-readable identifier for this specific error
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }
        
        /// <summary>
        /// A URL pointing to a place in our documentation where you can read about the error
        /// </summary>
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }
        
        /// <summary>
        /// A more detailed human-readable description of what went wrong
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// A quick and simple description of what went wrong
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// A machine-readable identifier for the general category of error
        /// </summary>
        [JsonProperty("type")]
        public string ErrorType { get; set; }
    }
}