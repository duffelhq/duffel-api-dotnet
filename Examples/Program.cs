using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duffel.ApiClient;
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
                
            var offersResponse = await client.CreateOffersRequest(offersRequest);
            var offerToRender = offersResponse.Offers!
                .OrderBy(offer => offer.TotalEmissionsKg)
                .Select(offer => new
                {
                    Id = offer.Id,
                    Airline = offer.Owner,
                    Price = $"{offer.TotalAmount} [{offer.TotalCurrency}]",
                });
        }

    }
    
}

