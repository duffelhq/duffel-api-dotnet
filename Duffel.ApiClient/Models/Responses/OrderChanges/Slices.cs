using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses.OrderChanges
{
    public class Slices
    {
        /// <summary>
        /// The slices that will be added to the order
        /// </summary>
        [JsonProperty("add")]
        public IEnumerable<Orders.Slice> Add { get; set; }
        
        /// <summary>
        /// The slices that will be removed from the order
        /// </summary>
        [JsonProperty("remove")]
        public IEnumerable<Orders.Slice> Remove { get; set; }
    }
}