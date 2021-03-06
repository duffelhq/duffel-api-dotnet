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
        Task<OffersResponse> Create(OffersRequest request, bool returnOffers = true);

        Task<OffersResponse> Get(string offerRequestId);
        Task<DuffelResponsePage<IEnumerable<OffersResponse>>> List(string before = "", string after = "", int limit = 50);
        Task<IEnumerable<OffersResponse>> GetAll();
    }

    public class OfferRequests : BaseResource<OffersResponse>, IOfferRequests
    {
        public OfferRequests(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="returnOffers">
        /// When set to true, the offer request resource returned will include all the offers returned by the airlines.
        /// If set to false, the offer request resource won't include any offers.
        /// To retrieve the associated offers later, use the List Offers endpoint, specifying the offer_request_id.
        /// You should use this option if you want to take advantage of the pagination, sorting and filtering that the List Offers endpoint provides.
        /// </param>
        /// <returns></returns>
        public async Task<OffersResponse> Create(OffersRequest request, bool returnOffers = true)
        {
            var payload = OffersResponseConverter.Serialize(request);
            var result = await HttpClient.PostAsync($"air/offer_requests",
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