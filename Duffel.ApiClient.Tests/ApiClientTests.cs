namespace Duffel.ApiClient.Tests
{
    using System;
    using NUnit.Framework;

    public class DuffelApiClientTests
    {
        [Test]
        public void ThrowsArgumentExceptionIfAccessTokenIsEmpty()
        {
            var exception = Assert.Catch<ArgumentException>(() => new DuffelApiClient(string.Empty));
            Assert.That(
                "No access token provided. To create an access token, head to your dashboard at https://app.duffel.com/duffel/tokens and generate a token. (Parameter 'accessToken')",
                Is.EqualTo(exception?.Message)
            );
        }

        [Test]
        public void ThrowsArgumentExceptionIfAccessTokenIsNull()
        {
            var exception = Assert.Catch<ArgumentException>(() => new DuffelApiClient(null));
            Assert.That(
                "No access token provided. To create an access token, head to your dashboard at https://app.duffel.com/duffel/tokens and generate a token. (Parameter 'accessToken')",
                Is.EqualTo(exception?.Message)
            );
        }
    }
}