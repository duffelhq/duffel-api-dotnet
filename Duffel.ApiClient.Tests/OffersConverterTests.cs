using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Duffel.ApiClient.Interfaces.Models.Responses.Offers;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class OffersConverterTests
    {
        [Test]
        public void CanSerializeOffersRequestWithNoCabinClass()
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
        
        [TestCase(CabinClass.Any, "")]
        [TestCase(CabinClass.PremiumEconomy, ",\"cabin_class\":\"premium_economy\"")]
        public void CanSerializeOffersRequestWithSetCabinClass(CabinClass cabinClass, string cabinClassPayload)
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
                },
                CabinClass = cabinClass
            };

            
            var result = OffersResponseConverter.Serialize(request);

            var expectedPayload = "{\"data\":{\"passengers\":[{\"type\":\"adult\"},{\"type\":\"child\"},{\"type\":\"infant_without_seat\"}],\"slices\":[{\"origin\":\"SFO\",\"destination\":\"LAX\",\"departure_date\":\"2020-01-01\"}],\"requested_sources\":[\"united\"]" + cabinClassPayload + "}}";
            Check.That(result).Equals(expectedPayload);
        }

        
        [Test]
        public void CanDeserializeOffersResponse()
        {
            var offersResponse = OffersResponseConverter.Deserialize(JsonFixture.Load("offers_response_full_ow_sfo_jfk.json"));
            Check.That(offersResponse).IsNotNull().And.IsInstanceOf<OffersResponse>();

            Check.That(offersResponse.Id).Equals("orq_0000AFANuVr4l0DI9G8Fk0");
            Check.That(offersResponse.IsLiveMode).IsFalse();
            Check.That(offersResponse.CreatedAt).Equals(DateTime.Parse("2022-01-06T14:39:20.094701Z"));
            
            AssertSlicesDataCorrect(offersResponse.Slices!.ToList());
            AssertOffersDataCorrect(offersResponse.Offers!.ToList());
            AssertOfferLevelPassengerDataCorrect(offersResponse);
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

            var baggageAllowances = offerResponse
                .Slices.FirstOrDefault()!
                .Segments.FirstOrDefault()!
                .Passengers.FirstOrDefault()!
                .BaggageAllowances.OrderBy(allowance => allowance.BaggageType);

            Check.That(baggageAllowances).HasSize(2);
            Check.That(baggageAllowances.First().BaggageType).Equals(BaggageType.Checked);
            Check.That(baggageAllowances.First().Quantity).Equals(2);
            Check.That(baggageAllowances.Last().BaggageType).Equals(BaggageType.CarryOn);
            Check.That(baggageAllowances.Last().Quantity).Equals(2);


            // TODO: add more checks for full offer
        }
        
        private static void AssertOfferLevelPassengerDataCorrect(OffersResponse? offersResponse)
        {
            var passengers = offersResponse.Passengers!.ToList();
            Check.That(passengers).HasSize(1);
            var passenger = passengers.FirstOrDefault();
            Check.That(passenger.PassengerType).Equals(PassengerType.Adult);
            Check.That(passenger.Id).Equals("pas_0000AFANuVr4l0DI9G8Fk2");
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

            AssertSliceDataOnOfferCorrect(offer);
        }
        
        private static void AssertSliceDataOnOfferCorrect(Offer? offer)
        {
            Check.That(offer.Slices).HasSize(1);
            var slice = offer.Slices.First();

            Check.That(slice.FareBrandName).IsEqualTo("Refundable Main Cabin");
            Check.That(slice.Duration).IsEqualTo(TimeSpan.Parse("09:26:00"));
            Check.That(slice.Id).IsEqualTo("sli_0000AFANuyQ8YEtck6keHI");
            Check.That(slice.Origin).IsInstanceOf<Airport>().And.IsNotNull();
            Check.That(slice.Destination).IsInstanceOf<Airport>().And.IsNotNull();

            Check.That(slice.Segments).HasSize(2);
            var segment = slice.Segments.First();
            Check.That(segment.Destination.IataCode).Equals("DTW");
            Check.That(segment.Duration).Equals(TimeSpan.Parse("04:33"));
            Check.That(segment.MarketingCarrier.AirlineName).Equals("Delta Air Lines");
            Check.That(segment.MarketingCarrier.IataCode).Equals("DL");
            Check.That(segment.MarketingCarrierFlightNumber).Equals("2282");
            Check.That(segment.OperatingCarrier.AirlineName).Equals("Delta Air Lines");
            Check.That(segment.OperatingCarrier.IataCode).Equals("DL");
            Check.That(segment.OperatingCarrierFlightNumber).Equals("2282");

            AssertPassengerDataOnSegmentValid(segment);
        }

        private static void AssertPassengerDataOnSegmentValid(Segment? segment)
        {
            Check.That(segment.Passengers).HasSize(1);
            var passengerData = segment.Passengers.First();
            Check.That(passengerData.FareBasisCode).Equals("KAVZA0M6");
            Check.That(passengerData.CabinClass).Equals(CabinClass.Economy);
            Check.That(passengerData.CabinClassMarketingName).Equals("Economy");
            Check.That(passengerData.PassengerId).Equals("pas_0000AFANuVr4l0DI9G8Fk2");
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
            Check.That(owner.AirlineName).IsEqualTo("Delta Air Lines");
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