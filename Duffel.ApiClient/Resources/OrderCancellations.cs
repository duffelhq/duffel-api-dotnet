using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;

namespace Duffel.ApiClient.Resources
{
    public interface IOrderCancellations
    {
        /// <summary>
        /// To cancel an order, you'll need to create an order cancellation, check the refund_amount returned, and, if you're happy to go ahead and cancel the order.
        /// The refund specified by refund_amount, if any, will be returned to your original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        Task<OrderCancellation> Create(string orderId);

        /// <summary>
        /// Once you've created a pending order cancellation, you'll know the refund_amount you're due to get back.
        /// To actually cancel the order, you'll need to confirm the cancellation. The booking with the airline will be cancelled, and the refund_amount will be returned to the original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        Task<OrderCancellation> Confirm(string cancellationRequestId);

        /// <summary>
        /// Retrieves an order cancellation by its ID.
        /// </summary>
        Task<OrderCancellation> Get(string cancellationRequestId);

        Task<DuffelResponsePage<IEnumerable<OrderCancellation>>> List(string before = "", string after = "", int limit = 50, string order_id = "");
    }

    public class OrderCancellations : BaseResource<OrderCancellation>, IOrderCancellations
    {
        public OrderCancellations(HttpClient httpClient) : base(httpClient)
        {
        }
        
        /// <summary>
        /// To cancel an order, you'll need to create an order cancellation, check the refund_amount returned, and, if you're happy to go ahead and cancel the order.
        /// The refund specified by refund_amount, if any, will be returned to your original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        public async Task<OrderCancellation> Create(string orderId)
        {
            var payload = OrderCancellationConverter.Serialize(new OrderCancellationRequest
            {
                OrderId = orderId
            });
            
            var result = await HttpClient.PostAsync($"air/order_cancellations",
                new StringContent(payload, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            
            return await SingleItemResponseConverter.GetAndDeserialize<OrderCancellation>(result);
        }
        
        /// <summary>
        /// Once you've created a pending order cancellation, you'll know the refund_amount you're due to get back.
        /// To actually cancel the order, you'll need to confirm the cancellation. The booking with the airline will be cancelled, and the refund_amount will be returned to the original payment method (i.e. your Duffel balance). You'll then need to refund your customer (e.g. back to their credit/debit card).
        /// </summary>
        public async Task<OrderCancellation> Confirm(string cancellationRequestId)
        {
            var result = await HttpClient.PostAsync($"air/order_cancellations/{cancellationRequestId}/actions/confirm",
                new StringContent("", Encoding.UTF8, "application/json")).ConfigureAwait(false);
            
            return await SingleItemResponseConverter.GetAndDeserialize<OrderCancellation>(result);
        }
        
        /// <summary>
        /// Retrieves an order cancellation by its ID.
        /// </summary>
        public async Task<OrderCancellation> Get(string cancellationRequestId)
        {
            var result = await HttpClient.GetAsync($"air/order_cancellations/{cancellationRequestId}").ConfigureAwait(false);
            return await SingleItemResponseConverter.GetAndDeserialize<OrderCancellation>(result);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<OrderCancellation>>> List(string before = "", string after = "", int limit = 50, string order_id = "")
        {
            var url = $"air/order_cancellations?limit={limit}";

            if (!string.IsNullOrEmpty(before)) url += $"&{before}";
            if (!string.IsNullOrEmpty(after)) url += $"&{after}";
            if (!string.IsNullOrEmpty(order_id)) url += $"&order_id={order_id}";
            
            var result = await HttpClient.GetAsync(url).ConfigureAwait(false);
            var content = await result.Content.ReadAsStringAsync();
            return PagedResponseConverter.Deserialize<OrderCancellation>(content, result.StatusCode);
        }
    }
}