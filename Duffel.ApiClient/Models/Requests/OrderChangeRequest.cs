using System.Collections.Generic;
using Duffel.ApiClient.Converters.Json;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Requests
{
    public class OrderChangeRequest
    {
        /// <summary>
        /// The slices that make up this offer request. One-way journeys can be expressed using one slice, whereas return trips will need two.
        /// </summary>
        [JsonProperty("slices")]
        public OrderChangeSlices Slices { get; set; }
        
        /// <summary>
        /// The order ID you wish to change
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
    }

    public class OrderChangeSlices
    {
        /// <summary>
        /// The slices that you wish to remove from your order
        /// </summary>
        [JsonProperty(PropertyName = "remove", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SliceListToDictConverter))]
        public List<string> Remove { get; set; } 

        /// <summary>
        /// The search criteria for slices which you wish to add to your order
        /// </summary>
        [JsonProperty(PropertyName = "add", NullValueHandling = NullValueHandling.Ignore)]
        public List<ChangeSlice> Add { get; set; } 
    }
}