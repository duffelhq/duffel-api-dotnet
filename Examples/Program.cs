using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duffel.ApiClient;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Exceptions;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.IdentityDocuments;
using Duffel.ApiClient.Interfaces.Models.Payments;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using Passenger = Duffel.ApiClient.Interfaces.Models.Requests.Passenger;
using Slice = Duffel.ApiClient.Interfaces.Models.Requests.Slice;

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
            
            Console.WriteLine("Create a new offers request (search)...");
            var offersResponse = await client.OfferRequests.Create(offersRequest);
            Console.WriteLine($"Created a new offers request, with ID: {offersResponse.Id}");
            
            //Console.WriteLine("Total offer requests:");
            //var res = await client.OfferRequests.GetAll();
            //Console.WriteLine($"\t{res.Count()}");
            
            Console.WriteLine($"Retrieving data for offer request {offersResponse.Id}...");
            var result = await client.OfferRequests.Get(offersResponse.Id);
            Console.WriteLine($"Offers on that request: {result.Offers.Count()}");
            
            Console.WriteLine("Retrieving all offers one by one...");
            foreach (var offer in result.Offers)
            {
                try
                {
                    var o = await client.Offers.Get(offer.Id, true);
                    Console.WriteLine($"Retrieved offer with id: {offer.Id}");
                }
                catch (ApiDeserializationException e)
                {
                    Console.WriteLine(e.Payload);
                    throw;
                }
            }

            Console.WriteLine("Retrieving all offers via offer request id...");
            var allOffersInOfferRequest = await client.Offers.Get(offerRequestId: result.Id);
            
            
            var offerForUpdate = await client.Offers.Get(result.Offers.First().Id, true);
            var passengerForUpdate = offerForUpdate.Passengers.First();
            
            Console.WriteLine($"Updating passenger details to name, age & include loyalty programme account...");
            
            passengerForUpdate.FamilyName = "Doe";
            passengerForUpdate.GivenName = "Joe";
            passengerForUpdate.Age = 99;
            
            passengerForUpdate.LoyaltyProgrammeAccounts = new List<LoyaltyProgrammeAccount>
            {
                new LoyaltyProgrammeAccount
                {
                    AccountNumber = "accno_001",
                    AirlineIataCode = "aircode_567"
                }
            };

            var updatedPassenger =
                await client.Offers.UpdatePassenger(allOffersInOfferRequest.Data.First().Id, passengerForUpdate);
            
            var orderCreateRequest = new OrderRequest
            {
                OrderType = OrderType.Instant,
                Passengers = new List<OrderPassenger>
                {
                    new OrderPassenger
                    {
                        BornOn = "2000-01-01",
                        Email = "test@test.com",
                        FamilyName = updatedPassenger.GivenName,
                        Gender = Gender.Male,
                        GivenName = updatedPassenger.GivenName,
                        Id = updatedPassenger.Id,
                        IdentityDocuments = new List<IdentityDocument>
                        {
                            new Passport
                            {
                                ExpiresOn = "2033-03-03",
                                IssuingCountryCode = "GB",
                                UniqueIdentifier = "12345 678"
                            }
                        },
                        PassengerType = PassengerType.Adult,
                        PhoneNumber = "+44 7654544321",
                        InfantPassengerId = null,
                        Title = "Mr"
                    }
                },
                Payments = new List<Payment>
                {
                    new Balance
                    {
                        Amount = allOffersInOfferRequest.Data.First().TotalAmount,
                        Currency = allOffersInOfferRequest.Data.First().TotalCurrency
                    }
                },
                SelectedOffers = new List<string> { allOffersInOfferRequest.Data.First().Id },
            };
            
            Console.WriteLine($"Data after update: {JsonConvert.SerializeObject(updatedPassenger.LoyaltyProgrammeAccounts)}");
            
            try
            {
                Console.WriteLine("Attempting to create an order");
                var createdOrder = await client.Orders.Create(orderCreateRequest);
                Console.WriteLine($"Created order has ID: {createdOrder.Id}");
            }
            catch (ApiException e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e, Formatting.Indented));
            }
            
            Console.Write("Getting airports: ");
            var airports = await client.Airports.GetAll();
            Console.WriteLine($" {airports.Count()} in total");
            
            Console.Write("Getting airlines: ");
            var airlines = await client.Airlines.GetAll();
            Console.WriteLine($" {airlines.Count()} in total");
            
            Console.Write("Getting aircrafts: ");
            var aircrafts = await client.Aircrafts.GetAll();
            Console.WriteLine($" {aircrafts.Count()} in total");

            

            /*
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
                    var offer = await client.GetOffer(offerInList.Id);
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
            */
        }

    }
    
}

