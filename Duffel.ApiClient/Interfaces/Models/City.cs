using System.Collections.Generic;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class City : Place
    {
        [JsonProperty("airports")]
        public IEnumerable<Airport> Airports { get; set; }
    }
}