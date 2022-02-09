using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class RowSection
    {
        /// <summary>
        /// The elements that make up this section
        /// </summary>
        [JsonProperty("elements")]
        public IEnumerable<RowSectionElement> Elements { get; set; }

    }
}