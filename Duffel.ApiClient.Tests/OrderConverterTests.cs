using System.Collections.Generic;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.IdentityDocuments;
using Duffel.ApiClient.Interfaces.Models.Payments;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class OrderConverterTests
    {
        [Test]
        public void CanSerializeOrderRequest()
        {
            var request = new OrderRequest
            {
                OrderType = OrderType.Instant,
                Services = new List<Service>
                {
                    new Service { Id = "ase_00009hj8USM7Ncg31cB123", Quantity = 1 }
                },
                SelectedOffers = new List<string> { "off_00009htyDGjIfajdNBZRlw" },
                Payments = new List<Payment> { new Balance { Amount = "123.0", Currency = "USD" } },
                Passengers = new List<OrderPassenger>
                {
                    new OrderPassenger
                    {
                        BornOn = "1999-01-01",
                        Email = "john@doe.com",
                        FamilyName = "Doe",
                        Gender = Gender.Male,
                        GivenName = "John",
                        Id = "pas_00009hj8USM7Ncg31cBCLL",
                        IdentityDocuments = new List<IdentityDocument>
                        {
                            new Passport
                            {
                                ExpiresOn = "2222-01-02",
                                IssuingCountryCode = "GB",
                                UniqueIdentifier = "passport123"
                            }
                        },
                        PassengerType = PassengerType.Adult,
                        PhoneNumber = "+4407856033333"
                    }
                },
                Metadata = new Dictionary<string, string>
                {
                    { "payment_intent_id", "pit_00009htYpSCXrwaB9DnUm2" }
                }
            };

            var result = OrderConverter.Serialize(request);
            Check.That(result).Equals(JsonFixture.Load("order_request.json"));
        }

        [TestCase("order_create_response_lhg.json")]
        public void CanDeserializeOrderResponse(string fixtureName)
        {
            var payload = JsonFixture.Load(fixtureName);
            var order = JsonConvert.DeserializeObject<Order>(payload);

            Check.That(order).IsNotNull();

        }
    }
}