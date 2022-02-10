using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Responses.OrderChanges;

namespace Duffel.ApiClient.Resources
{
    public class OrderChangeOffers
    {
        private readonly HttpClient _httpClient;

        public OrderChangeOffers(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves an order change offer by its ID
        /// </summary>
        /// <param name="orderChangeOfferId">Duffel's unique identifier for the order change offer</param>
        public async Task<OrderChangeOffer> Get(string orderChangeOfferId)
        {
            var result = await _httpClient.GetAsync($"/air/order_change_offers/{orderChangeOfferId}");
            return await SingleItemResponseConverter.GetAndDeserialize<OrderChangeOffer>(result);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<OrderChangeOffer>>> List(string orderChangeRequestId, string before = "",
            string after = "", int limit = 50, int maxConnections = 2,
            string sortOrder = "total_amount")
        {
            var url =
                $"air/order_change_offers?offer_request_id={orderChangeRequestId}&limit={limit}&sort={sortOrder.ToLower()}&max_connections={maxConnections}";

            if (!string.IsNullOrEmpty(before)) url += $"&{before}";
            if (!string.IsNullOrEmpty(after)) url += $"&{after}";

            return await RetrievePaginatedContent<OrderChangeOffer>(url);
        }

        private async Task<DuffelResponsePage<IEnumerable<T>>> RetrievePaginatedContent<T>(string url) where T: class
        {
            var result = await _httpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return PagedResponseConverter.Deserialize<T>(content, result.StatusCode);
        }
    }
}