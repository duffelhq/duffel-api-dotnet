using System.Net;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Responses;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class PaymentConvertersTests
    {
        [Test]
        public void CanDeserialize()
        {
            var payload = JsonFixture.Load("payment_response.json");
            var result = SingleItemResponseConverter.Deserialize<PaymentResponse>(payload, HttpStatusCode.Accepted);
            Check.That(result).IsInstanceOf<PaymentResponse>();
            Check.That(result.PaymentType).Equals("balance");
        }
    }
}