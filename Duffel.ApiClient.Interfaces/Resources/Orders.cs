using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

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

        /// <summary>
        /// To cancel an order, you'll need to create an order cancellation, check the refund_amount returned, and, if you're happy to go ahead and cancel the order.
        /// The refund specified by refund_amount, if any, will be returned to your original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        public async Task<OrderCancellation> CreateOrderCancellation(string orderId)
        {
            var payload = OrderCancellationConverter.Serialize(new OrderCancellationRequest
            {
                OrderId = orderId
            });
            
            var result = await HttpClient.PostAsync($"air/order_cancellations",
                new StringContent(payload, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync(); 
            
            return OrderCancellationConverter.Deserialize(content);
        }

        /// <summary>
        /// Once you've created a pending order cancellation, you'll know the refund_amount you're due to get back.
        /// To actually cancel the order, you'll need to confirm the cancellation. The booking with the airline will be cancelled, and the refund_amount will be returned to the original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        public async Task<OrderCancellation> ConfirmOrderCancellation(string cancellationRequestId)
        {
            var result = await HttpClient.PostAsync($"air/order_cancellations/{cancellationRequestId}/actions/confirm",
                new StringContent("", Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            
            return OrderCancellationConverter.Deserialize(content);
        }

        /// <summary>
        /// Retrieves an order cancellation by its ID.
        /// </summary>
        public async Task<OrderCancellation> GetOrderCancellation(string cancellationRequestId)
        {
            var result = await HttpClient.GetAsync($"air/order_cancellations/{cancellationRequestId}");
            var content = await result.Content.ReadAsStringAsync();
            return OrderCancellationConverter.Deserialize(content);
        }

        public async Task<DuffelResponsePage<IEnumerable<OrderCancellation>>> GetOrderCancellations(string before = "", string after = "", int limit = 50, string order_id = "")
        {
            var url = $"air/order_cancellations?limit={limit}";

            if (!string.IsNullOrEmpty(before)) url += $"&{before}";
            if (!string.IsNullOrEmpty(after)) url += $"&{after}";
            if (!string.IsNullOrEmpty(order_id)) url += $"&order_id={order_id}";
            
            var result = await HttpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return PagedResponseConverter.Deserialize<OrderCancellation>(content);
        }
    }
}