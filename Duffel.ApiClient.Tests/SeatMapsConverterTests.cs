using System.Linq;
using Duffel.ApiClient.Converters.Json;
using Duffel.ApiClient.Models;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class SeatMapsConverterTests
    {
        [Test]
        public void CanDeSerializeSeatMaps()
        {
            var seatMaps = SeatMapsJsonConverter.DeserializeSeatsMap(JsonFixture.Load("seat_maps.json"));
            Check.That(seatMaps).IsNotNull();

            var cabin = seatMaps.First().Cabins.First();
            var elements  = cabin.Rows.SelectMany(row => row.Sections.SelectMany(s => s.Elements)).ToList();

            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Seat));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Bassinet));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Closet));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Empty));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Galley));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Lavatory));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.Stairs));
            Check.That(elements.Any(e => e.ElementType == RowSectionElementType.ExitRow));
        }

        [Test]
        public void CanDeSerializeDuffelAirwaysSeatMaps()
        {
            var seatMaps = SeatMapsJsonConverter.DeserializeSeatsMap(JsonFixture.Load("seat_maps_duffel.json"));
            Check.That(seatMaps).IsNotNull();

            var mapElements = seatMaps
                .SelectMany(seatMap => seatMap.Cabins
                    .SelectMany(c => c.Rows
                        .SelectMany(r => r.Sections
                            .SelectMany(s => s.Elements
                                .Select(element => element)))));


            var seats = mapElements.Where(element => 
                element.ElementType == RowSectionElementType.Seat && element.AvailableServices.Any());

            Check.That(mapElements.Any()).IsTrue();
        }
    }
    
}