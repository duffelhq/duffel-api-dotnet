using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duffel.ApiClient;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.Requests;

namespace Examples
{
    public class Examples
    {

        public static async Task Main(string[] args)
        {
            var client = new DuffelApiClient(args[0]);
            
            var offersRequest = new OffersRequest
            {
                Passengers = new List<Passenger> { new Passenger { PassengerType = PassengerType.Adult } },
                RequestedSources = new List<string> { "duffel_airways" },
                Slices = new List<Slice>
                {
                    new Slice
                    {
                        // We use a nonsensical route to make sure we get speedy, reliable Duffel Airways
                        Origin = "LHR",
                        Destination = "STN",
                        DepartureDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd")
                    }
                }
            };

            try
            {
                var offersResponse = await client.CreateOffersRequest(offersRequest);
                Console.WriteLine($"Retrieved {offersResponse.Offers.Count()} offers, Duffel offers request id: {offersResponse.Id}.");

                var pageOfOffers = await client.ListOffers(offersResponse.Id, 1);
                Console.WriteLine($"Retrieved offer {pageOfOffers.Data.First().Id} via ListOffers");
                while (!string.IsNullOrEmpty(pageOfOffers.NextPage))
                {
                    pageOfOffers = await client.ListOffers(offersResponse.Id, pageOfOffers.NextPage, pageOfOffers.Limit);
                    Console.WriteLine($"Retrieved offer {pageOfOffers.Data.First().Id} via ListOffers");
                }

                foreach (var offerInList in offersResponse.Offers.OrderBy(o => int.Parse(o.TotalEmissionsKg)))
                {
                    var offer = await client.GetSingleOffer(offerInList.Id);
                    Console.WriteLine($"Retrieved a single offer, ID: {offer.Id}");
                    Console.WriteLine(
                        $"Owner: {offer.Owner.AirlineName}, Total:{offer.TotalCurrency} {offer.TotalAmount}, emission: {offer.TotalEmissionsKg} kg");
                }
                
                var pageOfAirlines = await client.ListAirlines(limit: 1);
                Console.WriteLine($"Retrieved airline {pageOfAirlines.Data.First().AirlineName} via ListOffers");
                while (!string.IsNullOrEmpty(pageOfAirlines.NextPage))
                {
                    pageOfAirlines = await client.ListAirlines(pageOfAirlines.NextPage, pageOfAirlines.Limit);
                    Console.WriteLine($"Retrieved airline {pageOfAirlines.Data.First().AirlineName} via ListOffers");
                }

                var pageOfAirports = await client.ListAirports(limit:1);
                Console.WriteLine($"Retrieved airport {pageOfAirports.Data.First().PlaceName} via ListOffers");
                while (!string.IsNullOrEmpty(pageOfAirports.NextPage))
                {
                    pageOfAirports = await client.ListAirports(pageOfAirports.NextPage, pageOfAirports.Limit);
                    Console.WriteLine($"Retrieved airport {pageOfAirports.Data.First().PlaceName} via ListOffers");
                }


            }
            catch (ApiDeserializationException ade)
            {
                Console.WriteLine(ade.Payload);
            }
        }

    }
    
}

