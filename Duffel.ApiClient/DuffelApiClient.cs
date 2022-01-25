using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient
{
    public class DuffelApiClient : IDuffelApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        
        public DuffelApiClient(string accessToken)
        {
            
            _httpClient.BaseAddress = new Uri("https://api.duffel.com");
            
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Duffel-Version", "beta");
            
            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");
            
        }

        public async Task<OffersResponse> CreateOffersRequest(OffersRequest request)
        {
            // Note: temp code. This will be refactored to use streams, injectable http client, etc.
            var payload = OffersResponseConverter.Serialize(request);
            var result = await _httpClient.PostAsync("air/offer_requests", 
                new StringContent(payload,  Encoding.UTF8, "application/json"));
            var content = await result.Content.ReadAsStringAsync();
            return OffersResponseConverter.Deserialize(content);
        }

        /// <summary>
        /// You should use this API to get the complete, up-to-date information about an offer. This endpoint does not guarantee that the offer will be available at the time of booking.
        /// Due to limitations in airlines' systems, you may see changes to the offer (e.g a changed total_amount).
        /// Additionally, you may receive information that may have not been included in the original offer such as baggage allowances.
        /// Optionally, you can request information about additional available_services that you can book with this offer by specifying the return_available_services query parameter.
        /// </summary>
        /// <param name="offerId">Duffel's unique identifier for the offer</param>
        /// <returns></returns>
        public async Task<Offer> GetSingleOffer(string offerId)
        {
            var result = await _httpClient.GetAsync($"air/offers/{offerId}");
            var content = await result.Content.ReadAsStringAsync();
            return SingleOfferResponseConverter.Deserialize(content);
        }

        /// <summary>
        /// Retrieves a list of offers for a given offer request specified by its ID. Unless you specify a sort parameter, the results may be returned in any order.
        /// This endpoint does not return the complete, up-to-date information on each offer.
        /// The <see cref="GetSingleOffer"/> endpoint should be called for a given offer in order to get complete and up-to-date information.
        /// </summary>
        /// <param name="offersRequestId"></param>
        /// <returns></returns>
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId)
        {
            var result = await _httpClient.GetAsync($"air/offers/?offer_request_id={offersRequestId}");
            var content = await result.Content.ReadAsStringAsync();
            return PagedOffersResponseConverter.Deserialize(content);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId = null)
        {
            pageId = string.IsNullOrEmpty(pageId.Trim()) ? "" : $"&{pageId}";
            
            var result = await _httpClient.GetAsync($"air/offers/?offer_request_id={offersRequestId}{pageId}");
            var content = await result.Content.ReadAsStringAsync();
            return PagedOffersResponseConverter.Deserialize(content);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, int limit = 50)
        {
            var result = await _httpClient.GetAsync($"air/offers/?offer_request_id={offersRequestId}&limit={limit}");
            var content = await result.Content.ReadAsStringAsync();
            return PagedOffersResponseConverter.Deserialize(content);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId = null, int limit = 50)
        {
            pageId = string.IsNullOrEmpty(pageId.Trim()) ? "" : $"&{pageId}";
            
            var result = await _httpClient.GetAsync(
                $"air/offers/?offer_request_id={offersRequestId}&limit={limit}{pageId}");
            var content = await result.Content.ReadAsStringAsync();
            return PagedOffersResponseConverter.Deserialize(content);
        }
    }
}