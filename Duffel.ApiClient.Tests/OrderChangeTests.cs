using System.Collections.Generic;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Requests;
using NFluent;
using NUnit.Framework;

namespace Duffel.ApiClient.Tests
{
    public class OrderChangeTests
    {
        [Test]
        public void CanSerializeOrderChangeRequest()
        {
            var request = new OrderChangeRequest
            {
                OrderId = "ord_123",
                Slices = new OrderChangeSlices
                {
                    Remove = new List<string> { "abc", "def" },
                    Add = new List<ChangeSlice>
                    {
                        new ChangeSlice
                        {
                            CabinClass = CabinClass.Business,
                            Origin = "lhr",
                            Destination = "jfk",
                            DepartureDate = "2000-01-01"
                        }
                    }
                }
            };

            var payload = OrderChangeConverter.Serialize(request);

            Check.That(payload).Equals(JsonFixture.Load("change_order_request.json"));
        }
    }
}