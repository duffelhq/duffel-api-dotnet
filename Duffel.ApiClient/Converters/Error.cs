using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("type")]
        public string ErrorType { get; set; }
    }
}