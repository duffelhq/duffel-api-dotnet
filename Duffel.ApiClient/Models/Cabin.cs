using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models
{
    public class Cabin
    {
        /// <summary>
        /// The number of aisles in this cabin.
        /// If this is set to 1, each row of the cabin is split into two sections. If this is set to 2, each row of the cabin is split into three sections. 
        /// </summary>
        [JsonProperty("aisles")]
        public int Aisles { get; set; }
        
        /// <summary>
        /// The cabin class that the passenger will travel in on this segment
        /// Possible values: "first", "business", "premium_economy", or "economy"
        /// </summary>
        [JsonProperty("cabin_class")]
        public CabinClass CabinClass { get; set; }
        
        /// <summary>
        /// Level 0 is the main deck and level 1 is the upper deck above that, which is found on some large aircraft.
        /// </summary>
        [JsonProperty("deck")]
        public int Deck { get; set; }
        
        /// <summary>
        /// A list of rows in this cabin.
        /// Row sections are broken up by aisles. Rows are ordered from front to back of the aircraft.
        /// </summary>
        [JsonProperty("rows")]
        public IEnumerable<Row> Rows { get; set; }
        
        /// <summary>
        /// Where the wings of the aircraft are in relation to rows in the cabin.
        /// The numbers correspond to the indices of the first and the last row which are overwing. You can use this to draw a visual representation of the wings to help users get a better idea of what they will see outside their window.
        /// The indices are 0th-based and are for all rows, not just those that have seats.
        /// This is null when no rows of the cabin are overwing.
        /// </summary>
        [JsonProperty("wings")]
        public Wings Wings { get; set; }
    }
}