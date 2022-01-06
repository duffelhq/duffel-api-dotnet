using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using NFluent;
using NUnit.Framework;
using Slice = Duffel.ApiClient.Interfaces.Models.Requests.Slice;

namespace Duffel.ApiClient.Tests
{
    public class OffersConverterTests
    {
        [Test]
        public void CanSerializeOffersRequest()
        {
            var request = new OffersRequest
            {
                Passengers = new List<Passenger>
                {
                    new Passenger {PassengerType = PassengerType.Adult},
                    new Passenger {PassengerType = PassengerType.Child}
                },
                RequestedSources = new List<string> { "united" },
                Slices = new List<Slice>
                {
                    new Slice
                    {
                        Origin = "SFO",
                        Destination = "LAX",
                        DepartureDate = "2020-01-01"
                    }
                }
            };

            var result = OffersConverter.Serialize(request);
            Check.That(result).Equals("{\"data\":{\"passengers\":[{\"type\":\"adult\"},{\"type\":\"child\"}],\"slices\":[{\"origin\":\"SFO\",\"destination\":\"LAX\",\"departure_date\":\"2020-01-01\"}],\"requested_sources\":[\"united\"]}}");
        }
        
        [Test]
        public void CanDeserializeOffersResponse()
        {
            var offersResponse = OffersConverter.Deserialize(JsonFixture.Load("offers_response_ow_lax_sfo.json"));
     
            Check.That(offersResponse).IsNotNull().And.IsInstanceOf<OffersResponse>();
            Check.That(offersResponse.Slices).HasSize(1);
            
            var origin = offersResponse.Slices.First().Origin;
            var destination = offersResponse.Slices.First().Destination;

            Check.That(origin).IsInstanceOf<City>();
            Check.That(destination).IsInstanceOf<Airport>();
            Check.That((origin as City)?.Airports).HasSize(4);

            Check.That(offersResponse.Slices.First().DepartureDate).IsEqualTo("2021-06-15");
        }
    }
}