using System.Collections.Generic;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using CabinRowsSectionsElementJsonConverter = Duffel.ApiClient.Converters.Json.CabinRowsSectionsElementJsonConverter;

namespace Duffel.ApiClient.Models
{
    [JsonConverter(typeof(CabinRowsSectionsElementJsonConverter))]
    public class RowSectionElement
    {

        public RowSectionElementType ElementType { get; set; }
        
        /// <summary>
        /// Seats are considered a special kind of service. There will be at most one service per seat per passenger. A seat can only be booked for one passenger. If a seat has no available services (which will be represented as an empty list : []) then it's unavailable.
        /// </summary>
        [JsonProperty("available_services")]
        public IEnumerable<SeatService> AvailableServices { get; set; }
        
        /// <summary>
        /// The designator used to uniquely identify the seat, usually made up of a row number and a column letter
        /// </summary>
        [JsonProperty("designator")]
        public string Designator { get; set; }
        
        /// <summary>
        /// Each disclosure is text, in English, provided by the airline that describes the terms and conditions of this seat. We recommend showing this in your user interface to make sure that customers understand any restrictions and limitations.
        /// </summary>
        [JsonProperty("disclosures")]
        public IEnumerable<string> Disclosures { get; set; }
        
        /// <summary>
        /// A name which describes the type of seat, which you can display in your user interface to help customers to understand its features
        /// </summary>
        [JsonProperty("name")]
        public string ElementName { get; set; }

    }
    
    public enum RowSectionElementType
    {
        Seat,
        Bassinet,
        Empty,
        ExitRow,
        Lavatory,
        Galley,
        Closet,
        Stairs
    }
}