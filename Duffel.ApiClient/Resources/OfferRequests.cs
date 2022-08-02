using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using OffersResponseConverter = Duffel.ApiClient.Converters.OffersResponseConverter;

namespace Duffel.ApiClient.Resources
{
    public interface IOfferRequests
    {
        /// <summary>
        /// To search for flights, you'll need to create an offer request.
        /// An offer request describes the passengers and where and when they want to travel (in the form of a list of slices).
        /// It may also include additional filters (e.g. a particular cabin to travel in).
        /// </summary>
        /// <param name="request"></param>
        /// <param name="returnOffers">
        /// When set to true, the offer request resource returned will include all the offers returned by the airlines.
        /// If set to false, the offer request resource won't include any offers.
        /// To retrieve the associated offers later, use the List Offers endpoint, specifying the offer_request_id.
        /// You should use this option if you want to take advantage of the pagination, sorting and filtering that the List Offers endpoint provides.
        /// </param>
        /// <param name="supplierTimeout">
        /// The maximum amount of time in milliseconds to wait for each airline to respond.
        /// This timeout only applies to the response time of the call to the airline and doesn't include additional overhead added by Duffel.
        /// Value should be between 2 seconds and 60 seconds.
        /// Any values outside the range will be ignored and the default supplierTimeout will be used.
        /// If a value is set, the response will only include offers from airlines that returned within the given time.
        /// If a value is not set, the response will only include offers from airlines that returned within the default supplierTimeout value of 20 seconds.
        /// We recommend setting supplierTimeout lower than the timeout on the request sent to Duffel API as that will allow us to respond with the offers we received before your request times out with an empty response.
        /// </param>
        Task<OffersResponse> Create(OffersRequest request, bool returnOffers = true, int supplierTimeout = 20000);

        Task<OffersResponse> Get(string offerRequestId);
        Task<DuffelResponsePage<IEnumerable<OffersResponse>>> List(string before = "", string after = "", int limit = 50);
        Task<IEnumerable<OffersResponse>> GetAll();
    }

    public class OfferRequests : BaseResource<OffersResponse>, IOfferRequests
    {
        public OfferRequests(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <inheritdoc />
        public async Task<OffersResponse> Create(OffersRequest request, bool returnOffers = true, int supplierTimeout = 20000)
        {
            var payload = OffersResponseConverter.Serialize(request);
            var result = await HttpClient.PostAsync($"air/offer_requests?returnOffers={(returnOffers ? "true" : "false")}&supplier_timeout={supplierTimeout}",
                new StringContent(payload, Encoding.UTF8, "application/json")).ConfigureAwait(false);

            return await SingleItemResponseConverter.GetAndDeserialize<OffersResponse>(result);
        }

        public async Task<OffersResponse> Get(string offerRequestId)
        {
            var result = await HttpClient.GetAsync($"air/offer_requests/{offerRequestId}").ConfigureAwait(false);
            return await SingleItemResponseConverter.GetAndDeserialize<OffersResponse>(result);
        }

        public async Task<DuffelResponsePage<IEnumerable<OffersResponse>>> List(string before = "", string after = "", int limit = 50)
        {
            var withBefore = string.IsNullOrEmpty(before) ? "" : $"&{before}";
            var withAfter = string.IsNullOrEmpty(after) ? "" : $"&{after}";

            return await RetrievePaginatedContent($"air/offer_requests?limit={limit}{withBefore}{withAfter}");
        }

        public async Task<IEnumerable<OffersResponse>> GetAll()
        {
            List<OffersResponse> result = new List<OffersResponse>();
            var page = await List(limit: 200);
            result.AddRange(page.Data);
            while (!string.IsNullOrEmpty(page.After))
            {
                page = await List(limit: 200, after: page.After, before: page.Before);
                result.AddRange(page.Data);
            }

            return result.AsEnumerable();
        }

    }
}
