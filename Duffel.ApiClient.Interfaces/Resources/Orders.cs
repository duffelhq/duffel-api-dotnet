using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class Orders : BaseResource<Order>
    {
        public Orders(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Creates a booking with an airline based on an offer.
        /// Orders are usually paid at the time of creation, but can be held and paid for at a later date if the offer supports it (see offer.payment_requirements.requires_instant_payment). To create an order and pay for it at the same time, specify a payments key. To hold the order and pay for it later, specify the type as hold, omit the payments and services keys, and complete payment after creating the order through the Create a payment endpoint.
        /// When presenting an order confirmation to your customers (e.g. on screen or in an email), you should include the booking_reference and details of the full itinerary and show the full name of the operating carrier of each segment (slices[].segments[].operating_carrier.name) in order to comply with US regulations.
        /// If you receive a 500 Internal Server Error when trying to create an order, it may have still been created on the airline’s side. Please contact Duffel support before trying the request again. 
        /// </summary>
        public async Task<Order> Create(OrderRequest request)
        {
            var payload = OrderConverter.Serialize(request);
            var result = await HttpClient.PostAsync($"air/orders",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            return OrderConverter.Deserialize(content);
        }

        public async Task<Order> Get(string orderId)
        {
            var result = await HttpClient.GetAsync($"air/orders/{orderId}");
            var content = await result.Content.ReadAsStringAsync();
            return OrderConverter.Deserialize(content);
        }

        public async Task<Order> Update(string orderId, OrderMetadata metadata)
        {
            var payload = OrderConverter.SerializeMetadata(metadata);
            
            var result = await HttpClient.PatchAsync($"air/orders/{orderId}",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            return OrderConverter.Deserialize(content);
        }
    }
}