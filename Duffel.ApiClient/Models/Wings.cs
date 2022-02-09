using Newtonsoft.Json;

namespace Duffel.ApiClient.Models
{
    public class Wings
    {
        /// <summary>
        /// The index of the first row which is overwing, starting from the front of the aircraft.
        /// </summary>
        [JsonProperty("first_row_index")]
        public int FirstRowIndex { get; set; }
        
        /// <summary>
        /// The index of the last row which is overwing, starting from the front of the aircraft.
        /// </summary>
        [JsonProperty("last_row_index")]
        public int LastRowIndex { get; set; }
    }
}