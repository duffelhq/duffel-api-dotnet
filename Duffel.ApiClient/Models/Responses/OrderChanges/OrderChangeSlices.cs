using System.Collections.Generic;
using Duffel.ApiClient.Models.Responses.Orders;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses.OrderChanges
{
    public class OrderChangeSlices
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