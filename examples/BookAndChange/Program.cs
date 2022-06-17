using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Duffel.ApiClient;
using Duffel.ApiClient.Exceptions;
using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Payments;
using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;

var accessToken = Environment.GetEnvironmentVariable("DUFFEL_ACCESS_TOKEN");
var client = new DuffelApiClient(accessToken: accessToken);

try
{
    var offersRequest = new OffersRequest
    {
        CabinClass = CabinClass.Economy,
        Passengers = new List<Passenger>() {new Passenger {PassengerType = PassengerType.Adult}},
        Slices = new List<Slice>
        {
            new()
            {
                // We use a nonsensical route to make sure we get speedy, reliable "Duffel Airways" results
                Origin = "LHR",
                Destination = "STN",
                DepartureDate = DateTime.Now.AddMonths(12).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
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

    var bagService = pricedOffer.AvailableServices.First();
    Console.WriteLine($"Adding an extra bag with service {bagService.Id}");
    Console.WriteLine($"Costing {bagService.TotalCurrency} {bagService.TotalAmount}");

    var totalAmount = float.Parse(pricedOffer.TotalAmount, CultureInfo.InvariantCulture) +
                      float.Parse(bagService.TotalAmount, CultureInfo.InvariantCulture);

    var orderRequest = new OrderRequest
    {
        SelectedOffers = new[] {pricedOffer.Id}.ToList(),
        Services = new List<Service>() {new() {Id = bagService.Id, Quantity = 1}},
        Payments =
            new[]
            {
                new Balance
                {
                    Amount = totalAmount.ToString(CultureInfo.InvariantCulture),
                    Currency = pricedOffer.TotalCurrency
                }
            }.ToList(),
        Passengers = new[]
        {
            new OrderPassenger
            {
                Id = pricedOffer.Passengers.First().Id,
                Title = "Mr",
                Gender = Gender.Male,
                GivenName = "John",
                FamilyName = "Doe",
                BornOn = "1990-01-01",
                PhoneNumber = "+441290211999",
                Email = "john.doe@test.com"
            }
        }.ToList()
    };

    var order = await client.Orders.Create(orderRequest);
    Console.WriteLine($"Created order {order.Id} with booking reference {order.BookingReference}");

    var orderChangeRequest = await client.OrderChangeRequests.Create(new OrderChangeRequest
    {
        OrderId = order.Id,
        Slices = new OrderChangeSlices
        {
            Add = new List<ChangeSlice>
            {
                new ChangeSlice
                {
                    CabinClass = CabinClass.Economy,
                    DepartureDate =
                        DateTime.Now.AddMonths(11).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Origin = "LHR",
                    Destination = "STN"
                }
            }
        }
    });

    var orderChangeOffers = await client.OrderChangeOffers.List(orderChangeRequest.Id);
    Console.WriteLine("Picking first option for changing the order.");

    var orderChange = await client.OrderChanges.Create(orderChangeOffers.Data.First().Id);
    Console.WriteLine($"Created order change with ID: {orderChange.Id}, confirming...");

    var confirmedOrderChange = await client.OrderChanges.Confirm(orderChange.Id,
        new Balance {Amount = orderChange.ChangeTotalAmount, Currency = orderChange.ChangeTotalCurrency});

}
catch (ApiException apiException)
{
    Console.WriteLine(
        $"Failed with status: {apiException.Metadata.Status}, request Id: {apiException.Metadata.RequestId}");
    foreach (var apiExceptionError in apiException.Errors)
    {
        Console.WriteLine(apiExceptionError.Message);
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}
