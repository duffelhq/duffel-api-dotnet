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

var bagService = pricedOffer.AvailableServices.First();
Console.WriteLine($"Adding an extra bag with service {bagService.Id}");
Console.WriteLine($"Costing {bagService.TotalCurrency} {bagService.TotalAmount}");

var totalAmount = float.Parse(pricedOffer.TotalAmount) + float.Parse(bagService.TotalAmount);

var orderRequest = new OrderRequest
{
    OrderType = OrderType.Hold,
    SelectedOffers = new List<string>{ pricedOffer.Id },
    Passengers = new List<OrderPassenger>
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
    }
};

var order = await client.Orders.Create(orderRequest);
Console.WriteLine($"Created HOLD order {order.Id} with booking reference {order.BookingReference}");

var updatedOrder = await client.Orders.Get(order.Id);
Console.WriteLine($"Retrieved order an up-to-date price: {updatedOrder.TotalCurrency} {updatedOrder.TotalAmount}");

var payment = await client.Payments.Create(new PaymentRequest
{
    OrderId = order.Id,
    Payment = new Balance
    {
        Amount = updatedOrder.TotalAmount,
        Currency = updatedOrder.TotalCurrency
    }
});

Console.WriteLine($"Paid for order {order.Id} with payment {payment.Id}");

var paidOrder = await client.Orders.Get(order.Id);

Console.WriteLine($"After payment, order has {paidOrder.Documents.Count()} documents");
Console.WriteLine(JsonConvert.SerializeObject(paidOrder.Documents, Formatting.Indented));