using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models
{
    public class Row
    {
        /// <summary>
        /// A list of sections.
        /// Each row is divided into sections by one or more aisles.
        /// </summary>
        [JsonProperty("sections")]
        public IEnumerable<RowSection> Sections { get; set; }
    }
}