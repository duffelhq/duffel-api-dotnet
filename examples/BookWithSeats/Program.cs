using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient;
using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Payments;
using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;

var accessToken = Environment.GetEnvironmentVariable("DUFFEL_ACCESS_TOKEN");
var client = new DuffelApiClient(accessToken: accessToken, production: false);

var offersRequest = new OffersRequest
{
    CabinClass = CabinClass.Economy,
    Passengers = new List<Passenger>() { new Passenger { PassengerType = PassengerType.Adult } },
    Slices = new List<Slice>
    {
        new Slice
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

var selectedOffer = response.Offers.First();
Console.WriteLine($"Selected for booking offer with ID: {selectedOffer.Id}");

var pricedOffer = await client.Offers.Get(selectedOffer.Id, returnAvailableServices: true);
Console.WriteLine($"The final price for selected offer is {pricedOffer.TotalCurrency} {pricedOffer.TotalAmount}");

var seatMaps = await client.SeatMaps.Get(pricedOffer.Id);

var availableSeats = seatMaps
    .SelectMany(seatMap => seatMap.Cabins
        .SelectMany(c => c.Rows
            .SelectMany(r => r.Sections
                .SelectMany(s => s.Elements
                    .Where(element => element.ElementType == RowSectionElementType.Seat && element.AvailableServices.Any())
                    .Select(element => element)))));

var seat = availableSeats.First();
var seatService = seat.AvailableServices.First();

Console.WriteLine($"Adding seat {seat.Designator} costing {seatService.TotalCurrency} {seatService.TotalAmount}");

var totalAmount = float.Parse(pricedOffer.TotalAmount) + float.Parse(seatService.TotalAmount);

var orderRequest = new OrderRequest
{
    SelectedOffers = new List<string> { pricedOffer.Id },
    Services = new List<Service> { new() { Id = seatService.Id, Quantity = 1 } },
    Payments = new List<Payment> {new Balance { Amount = totalAmount.ToString(), Currency = pricedOffer.TotalCurrency}},
    Passengers = new List<OrderPassenger> { new()
    {
        Id = pricedOffer.Passengers.First().Id,
        Title = "Mr",
        Gender = Gender.Male,
        GivenName = "John",
        FamilyName = "Doe",
        BornOn = "1990-01-01",
        PhoneNumber = "+441290211999",
        Email = "john.doe@test.com"
    }}
};

var order = await client.Orders.Create(orderRequest);

Console.WriteLine($"Created order {order.Id} with booking ref: {order.BookingReference}");

