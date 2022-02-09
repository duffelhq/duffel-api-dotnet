using System;
using System.Collections.Generic;
using Duffel.ApiClient.Converters.Json;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Models.Responses.Offers
{
    public class Segment
    {
        /// <summary>
        /// Additional segment-specific information about the passengers included in the offer (e.g. their baggage allowance and the cabin class they will be travelling in)
        /// </summary>
        [JsonProperty("passengers")]
        public IEnumerable<SegmentPassenger> Passengers { get; set; }

        /// <summary>
        /// The terminal at the origin airport from which the segment is scheduled to depart
        /// Nullable
        /// </summary>
        [JsonProperty("origin_terminal")]
        public string OriginTerminal { get; set; }
        
        /// <summary>
        /// The airport from which the flight is scheduled to depart
        /// </summary>
        [JsonProperty("origin")]
        public Airport Origin { get; set; } // TODO: Can this be a City as well?
        
        /// <summary>
        /// The flight number assigned by the <see cref="OperatingCarrier"/>.
        /// This may not be present, in which case you should display the <see cref="MarketingCarrier"/>'s information and the <see cref="MarketingCarrierFlightNumber"/>,
        /// and simply state the name of the operating_carrier.
        /// </summary>
        [JsonProperty("operating_carrier_flight_number")]
        public string OperatingCarrierFlightNumber { get; set; }
        
        /// <summary>
        /// The airline actually operating this segment. This may differ from the <see cref="MarketingCarrier"/> in the case of a "codeshare", where one airline sells flights operated by another airline.
        /// </summary>
        [JsonProperty("operating_carrier")]
        public Airline OperatingCarrier { get; set; }

        /// <summary>
        /// The flight number assigned by the marketing carrier
        /// </summary>
        [JsonProperty("marketing_carrier_flight_number")]
        public string MarketingCarrierFlightNumber { get; set; }
        
        /// <summary>
        /// The airline selling the tickets for this segment.
        /// This may differ from the <see cref="OperatingCarrier"/> in the case of a "codeshare", where one airline sells flights operated by another airline.
        /// </summary>
        [JsonProperty("marketing_carrier")]
        public Airline MarketingCarrier { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("duration")]
        [JsonConverter(typeof(StringDurationToTimeStampJsonConverter))]
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// The distance of the segment in kilometres
        /// </summary>
        [JsonProperty("distance")]
        public string Distance { get; set; }

        /// <summary>
        /// The terminal at the <see cref="Destination"/>  <see cref="Airport"/> where the segment is scheduled to
        /// </summary>
        [JsonProperty("destination_terminal")]
        public string DestinationTerminal { get; set; }
        
        [JsonProperty("destination")]
        public Airport Destination { get; set; }
        
        [JsonProperty("departing_at")]
        public DateTime DepartingAt { get; set; }
        
        [JsonProperty("arriving_at")]
        public DateTime ArrivingAt { get; set; }
        
        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }
    }
}