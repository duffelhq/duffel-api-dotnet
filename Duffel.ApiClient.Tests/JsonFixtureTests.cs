using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class JsonFixtureTests
    {
        [Test]
        public void CanAccessAndLoadFixtureFile()
        {
            var content = JsonFixture.Load("offers_response_ow_lax_sfo.json");
            Check.That(content).IsNotNull();
        }
    }
}