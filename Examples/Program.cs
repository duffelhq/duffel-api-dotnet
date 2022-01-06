
using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient;
using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Requests;

var client = new DuffelApiClient(args[0]);
var offers = await client.Offers.Request(new OffersRequest
{
    Passengers = new List<Passenger> { new Passenger { PassengerType = PassengerType.Adult }},
    RequestedSources = new List<string> { "duffel_airways" },
    Slices = new List<Slice>
    {
        new Slice
        {
            Origin = "SFO",
            Destination = "JFK",
            DepartureDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd")
        }
    }
});

offers.Slices.ToList().ForEach(slice => Console.WriteLine($"Slice: {slice.Origin.Id} -> {slice.Destination.Id}"));


