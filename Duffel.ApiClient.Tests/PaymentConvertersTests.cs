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
            var result = PaymentResponseConverter.Deserialize(payload);
            Check.That(result).IsInstanceOf<PaymentResponse>();
            Check.That(result.PaymentType).Equals("balance");
        }
    }
}