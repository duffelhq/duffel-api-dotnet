using System;
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
    public class OfferRequests : BaseResource<OffersResponse>
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
            // TODO: returnOffers does not work?
            var payload = OffersResponseConverter.Serialize(request);
            var result = await HttpClient.PostAsync($"air/offer_requests", 
                new StringContent(payload,  Encoding.UTF8, "application/json"));

            return await SingleItemResponseConverter.GetAndDeserialize<OffersResponse>(result);
        }

        public async Task<OffersResponse> Get(string offerRequestId)
        {
            var result = await HttpClient.GetAsync($"air/offer_requests/{offerRequestId}");
            return await SingleItemResponseConverter.GetAndDeserialize<OffersResponse>(result);
        }

        public async Task<DuffelResponsePage<IEnumerable<OffersResponse>>> Get(string before = "", string after = "", int limit = 50)
        {
            return await RetrievePaginatedContent($"air/offer_requests?limit={limit}&{after}");
        }

        public async Task<IEnumerable<OffersResponse>> GetAll()
        {
            List<OffersResponse> result = new List<OffersResponse>();
            var page = await Get(limit: 200);
            result.AddRange(page.Data);
            while (!string.IsNullOrEmpty(page.NextPage))
            {
                page = await Get(limit: 200, after: page.NextPage, before: page.PreviousPage);
                result.AddRange(page.Data);
            }

            return result.AsEnumerable();
        }

    }
}