using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Duffel.ApiClient;
using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using Passenger = Duffel.ApiClient.Models.Requests.Passenger;
using Slice = Duffel.ApiClient.Models.Requests.Slice;

var accessToken = Environment.GetEnvironmentVariable("DUFFEL_ACCESS_TOKEN");
var client = new DuffelApiClient(accessToken: accessToken, production: false);

Console.WriteLine("Loading airports...");
var airports = await client.Airports.GetAll();
Console.WriteLine($"Retrieved {airports.Count()} airports");
Console.WriteLine($"Loading single airport {airports.First().PlaceName} {airports.First().IataCode}");
var airport = await client.Airports.Get(airports.First().Id);
Console.WriteLine($"Airport is located at geolocation: {airport.Latitude}, {airport.Longitude}");
Console.WriteLine($"Airport is located in or near {airport.CityName}");

Console.WriteLine("Loading aircrafts...");
var aircrafts = await client.Aircrafts.GetAll();
Console.WriteLine($"Retrieved {aircrafts.Count()} aircrafts");
Console.WriteLine($"Loading single aircraft {aircrafts.First().AircraftName}");
var aircraft = await client.Aircrafts.Get(aircrafts.First().Id);
Console.WriteLine($"Aircraft IATA: {aircraft.IataCode}");

Console.WriteLine("Loading airlines...");
var airlines = await client.Airlines.GetAll();
Console.WriteLine($"Retrieved {airlines.Count()} airlines");
Console.WriteLine($"Loading single airline {airlines.First().AirlineName}");
var airline = await client.Airlines.Get(airlines.First().Id);
Console.WriteLine($"Airline IATA: {airline.IataCode}");

var offersRequest = new OffersRequest
{
    CabinClass = CabinClass.Economy,
    Passengers = new List<Passenger>() { new Passenger { PassengerType = PassengerType.Adult } },
    //RequestedSources = new List<string> { "lufthansa_group" },
    Slices = new List<Slice>
    {
        new()
        {
            // We use a nonsensical route to make sure we get speedy, reliable "Duffel Airways" results
            Origin = "LHR",
            Destination = "STN",
            DepartureDate = DateTime.Now.AddMonths(12).ToString("yyyy-MM-dd")
        }
    }
};

Console.WriteLine("Requesting offers");
var response = await client.OfferRequests.Create(offersRequest, returnOffers: false);
Console.WriteLine($"Retrieved {response.Offers.Count()} offers");
