using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Exceptions;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Duffel.ApiClient.Resources
{
    public class Offers : BaseResource<Offer>
    {
        public Offers(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Offer> Get(string offerId, bool returnAvailableServices = true)
        {
            var result = await HttpClient.GetAsync($"air/offers/{offerId}");
            var content = await result.Content.ReadAsStringAsync();
            return SingleItemResponseConverter.Deserialize<Offer>(content);
        }

        public async Task<DuffelResponsePage<IEnumerable<Offer>>> Get(string offerRequestId, string before = "",
            string after = "", int limit = 50, int maxConnections = 2,
            string sortOrder = "total_amount")
        {
            var url =
                $"air/offers?offer_request_id={offerRequestId}&limit={limit}&sort={sortOrder}&max_connections={maxConnections}";

            if (!string.IsNullOrEmpty(before)) url += $"&{before}";
            if (!string.IsNullOrEmpty(after)) url += $"&{after}";

            return await RetrievePaginatedContent(url);
        }

        public async Task<Passenger> UpdatePassenger(string offerId, Passenger passengerData)
        {
            var payload = JsonConvert.SerializeObject(new DuffelDataWrapper<Passenger>(passengerData), Formatting.None, new StringEnumConverter());
            var result = await HttpClient.PatchAsync($"air/offers/{offerId}/passengers/{passengerData.Id}", new StringContent(payload, Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<DuffelResponseWrapper<Passenger>>(content);
            if (response != null && response.Errors != null && response.Errors.Any())
            {
                throw new ApiException(response.Metadata, response.Errors);
            }
            return response!.Data!;
        }
    }
}