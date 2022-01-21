using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class OffersConverterTests
    {
        [Test]
        public void CanSerializeOffersRequest()
        {
            var request = new OffersRequest
            {
                Passengers = new List<Interfaces.Models.Requests.Passenger>
                {
                    new() { PassengerType = PassengerType.Adult },
                    new() { PassengerType = PassengerType.Child },
                    new() { PassengerType = PassengerType.Infant }
                },
                RequestedSources = new List<string> { "united" },
                Slices = new List<Interfaces.Models.Requests.Slice>
                {
                    new()
                    {
                        Origin = "SFO",
                        Destination = "LAX",
                        DepartureDate = "2020-01-01"
                    }
                }
            };

            var result = OffersResponseConverter.Serialize(request);
            Check.That(result).Equals("{\"data\":{\"passengers\":[{\"type\":\"adult\"},{\"type\":\"child\"},{\"type\":\"infant_without_seat\"}],\"slices\":[{\"origin\":\"SFO\",\"destination\":\"LAX\",\"departure_date\":\"2020-01-01\"}],\"requested_sources\":[\"united\"]}}");
        }
        
        [Test]
        public void CanDeserializeOffersResponse()
        {
            var offersResponse = OffersResponseConverter.Deserialize(JsonFixture.Load("offers_response_full_ow_sfo_jfk.json"));
            Check.That(offersResponse).IsNotNull().And.IsInstanceOf<OffersResponse>();
            
            AssertSlicesDataCorrect(offersResponse.Slices!.ToList());
            AssertOffersDataCorrect(offersResponse.Offers!.ToList());
            AssertOfferLevelPassengerDataCorrect(offersResponse);
        }

        private static void AssertOfferLevelPassengerDataCorrect(OffersResponse? offersResponse)
        {
            var passengers = offersResponse.Passengers!.ToList();
            Check.That(passengers).HasSize(1);
            var passenger = passengers.FirstOrDefault();
            Check.That(passenger.PassengerType).Equals(PassengerType.Adult);
            Check.That(passenger.Id).Equals("pas_0000AFANuVr4l0DI9G8Fk2");
        }

        [Test]
        public void CanDeserializeSingleOfferResponse()
        {
            var offerResponse = SingleOfferResponseConverter.Deserialize(JsonFixture.Load("offer_response_ow_3pass_ber_lhr.json"));
            Check.That(offerResponse).IsNotNull().And.IsInstanceOf<Offer>();

            Check.That(offerResponse.PaymentRequirements).IsNotNull();
            Check.That(offerResponse.PaymentRequirements.RequiresInstantPayment).IsFalse();
            Check.That(offerResponse.PaymentRequirements.PriceGuaranteeExpiresAt).IsNull();
            Check.That(offerResponse.PaymentRequirements.PaymentRequiredBy).Equals(new DateTime(2022, 5, 23, 22, 45, 0, DateTimeKind.Utc));
            
            // TODO: add more checks for full offer
        }

        private static void AssertOffersDataCorrect(List<Offer> offers)
        {
            Check.That(offers).HasSize(4);
            
            var offer = offers.First();
            Check.That(offer.Id).IsEqualTo("off_0000AFANuyPmZYc2j0aMj7");
            Check.That(offer.LiveMode).IsFalse();
            Check.That(offer.BaseCurrency).Equals("GBP");
            Check.That(offer.BaseAmount).Equals("431.66");

            AssertOwnerPresentAndCorrect(offer);
            AssertPassengerDataCorrect(offer);

            Check.That(offer.PaymentRequirements).IsNotNull();
            Check.That(offer.PaymentRequirements.RequiresInstantPayment).IsTrue();
            Check.That(offer.PaymentRequirements.PaymentRequiredBy).IsNull();
            Check.That(offer.PaymentRequirements.PriceGuaranteeExpiresAt).IsNull();

            Check.That(offer.Slices).HasSize(1);
            var slice = offer.Slices.First();
            
            Check.That(slice.FareBrandName).IsEqualTo("Refundable Main Cabin");
            Check.That(slice.Duration).IsEqualTo(TimeSpan.Parse("09:26:00"));
            Check.That(slice.Id).IsEqualTo("sli_0000AFANuyQ8YEtck6keHI");
            Check.That(slice.Origin).IsInstanceOf<Airport>().And.IsNotNull();
            Check.That(slice.Destination).IsInstanceOf<Airport>().And.IsNotNull();
            
            // TODO: add segments
        }

        private static void AssertPassengerDataCorrect(Offer? offer)
        {
            Check.That(offer.Passengers).HasSize(1);

            var passenger = offer.Passengers.First();
            Check.That(passenger.Id).IsEqualTo("pas_0000AFANuVr4l0DI9G8Fk2");
            Check.That(passenger.PassengerType).IsEqualTo(PassengerType.Adult);
            Check.That(passenger.LoyaltyProgrammeAccounts).HasSize(0);
        }

        private static void AssertOwnerPresentAndCorrect(Offer? offer)
        {
            var owner = offer.Owner;
            Check.That(owner).IsNotNull();
            Check.That(owner.Id).IsEqualTo("arl_00009VME7DBgd2sGtBN3HF");
            Check.That(owner.Name).IsEqualTo("Delta Air Lines");
            Check.That(owner.IataCode).IsEqualTo("DL");
        }

        private static void AssertSlicesDataCorrect(List<Interfaces.Models.Responses.Slice> slices)
        {
            Check.That(slices).HasSize(1);

            var origin = slices.First().Origin;
            var destination = slices.First().Destination;

            Check.That(origin).IsInstanceOf<Airport>();
            Check.That(destination).IsInstanceOf<Airport>();
            Check.That(slices.First().DepartureDate).IsEqualTo("2022-02-05");
        }
    }
}