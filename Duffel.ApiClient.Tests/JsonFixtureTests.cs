using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class JsonFixtureTests
    {
        [Test]
        public void CanAccessAndLoadFixtureFile()
        {
            var content = JsonFixture.Load("offers_response_full_ow_sfo_jfk.json");
            Check.That(content).IsNotNull();
        }
    }
}