using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    using System;

    public class DuffelApiClientTests
    {
        [Test]
        public void ThrowsArgumentExceptionIfAccessTokenIsEmpty()
        {
            var exception = Assert.Catch<ArgumentException>(() => new DuffelApiClient(String.Empty));
            Assert.AreEqual("No access token provided. To create an access token, head to your dashboard at https://app.duffel.com/duffel/tokens and generate a token. (Parameter 'accessToken')", exception?.Message);
        }

        [Test]
        public void ThrowsArgumentExceptionIfAccessTokenIsNull()
        {
            var exception = Assert.Catch<ArgumentException>(() => new DuffelApiClient(null));
            Assert.AreEqual("No access token provided. To create an access token, head to your dashboard at https://app.duffel.com/duffel/tokens and generate a token. (Parameter 'accessToken')", exception?.Message);
        }
    }
}
