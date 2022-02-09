using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Exceptions;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Resources
{
    /// <summary>
    /// Seat maps are used to build a rich experience for your customers so they can select a seat as part of an order.
    /// A seat map includes the data for rendering seats in the relevant cabins, along with their total cost and other information such as disclosures.
    /// A seat is a special kind of service in that they're not shown when getting an individual offer with return_available_services set to true. They're only available through this endpoint.
    /// So far we support selecting seats when you create an order. This means we do not support selecting a seat after an order has already been created or cancelling a booked seat.
    /// </summary>
    public class SeatMaps
    {
        private readonly HttpClient _httpClient;

        public SeatMaps(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SeatMaps>> Get(string offerId)
        {
            var result = await _httpClient.GetAsync($"air/seat_maps?offer_id={offerId}");
            var content = await result.Content.ReadAsStringAsync();
            
            var wrappedResponse =
                JsonConvert.DeserializeObject<DuffelResponseWrapper<IEnumerable<SeatMaps>>>(content);

            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, content);
        }
    }
}