using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses.OrderChangeRequest
{
    public class Slices
    {
        /// <summary>
        /// The slices that will be added to the order
        /// </summary>
        [JsonProperty("add")]
        public IEnumerable<OrderChangeSlice> Add { get; set; }
        
 
        /// <summary>
        /// The slices that will be removed from the order
        /// </summary>
        [JsonProperty("remove")]
        public IEnumerable<OrderChangeSlice> Remove { get; set; }
    }
}