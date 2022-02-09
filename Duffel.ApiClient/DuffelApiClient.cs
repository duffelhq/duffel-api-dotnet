using System;
using System.Net.Http;
using Duffel.ApiClient.Resources;

namespace Duffel.ApiClient
{
    public class DuffelApiClient : IDuffelApiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        
        public Airlines Airlines { get; }
        public Airports Airports { get; }
        public Aircrafts Aircrafts { get; }
        public OfferRequests OfferRequests { get; }
        public Offers Offers { get; }
        public Orders Orders { get; }
        public SeatMaps SeatMaps { get; }
        public Payments Payments { get; }
        public OrderChangeRequests OrderChangeRequests { get; }
        public OrderChanges OrderChanges { get; }
        
        public DuffelApiClient(string accessToken, bool production = false)
        {
            _httpClient.BaseAddress = production ? new Uri("https://api.duffel.com") : new Uri("https://api.staging.duffel.com");

            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Duffel-Version", "beta");
            
            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            Airlines = new Airlines(_httpClient);
            Airports = new Airports(_httpClient);
            Aircrafts = new Aircrafts(_httpClient);
            OfferRequests = new OfferRequests(_httpClient);
            Offers = new Offers(_httpClient);
            Orders = new Orders(_httpClient);
            SeatMaps = new SeatMaps(_httpClient);
            Payments = new Payments(_httpClient);
            OrderChangeRequests = new OrderChangeRequests(_httpClient);
            OrderChanges = new OrderChanges(_httpClient);
        }
        
        /*

        /// <summary>
        /// You should use this API to get the complete, up-to-date information about an offer. This endpoint does not guarantee that the offer will be available at the time of booking.
        /// Due to limitations in airlines' systems, you may see changes to the offer (e.g a changed total_amount).
        /// Additionally, you may receive information that may have not been included in the original offer such as baggage allowances.
        /// Optionally, you can request information about additional available_services that you can book with this offer by specifying the return_available_services query parameter.
        /// </summary>
        /// <param name="offerId">Duffel's unique identifier for the offer</param>
        /// <returns></returns>
        public async Task<Offer> GetOffer(string offerId)
        {
            var result = await _httpClient.GetAsync($"air/offers/{offerId}");
            var content = await result.Content.ReadAsStringAsync();
            return SingleItemResponseConverter.Deserialize<Offer>(content);
        }

        /// <summary>
        /// Retrieves a list of offers for a given offer request specified by its ID. Unless you specify a sort parameter, the results may be returned in any order.
        /// This endpoint does not return the complete, up-to-date information on each offer.
        /// The <see cref="GetOffer"/> endpoint should be called for a given offer in order to get complete and up-to-date information.
        /// </summary>
        /// <param name="offersRequestId"></param>
        /// <returns></returns>
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId)
        {
            var url = $"air/offers/?offer_request_id={offersRequestId}";
            return await RetrievePaginatedContent<Offer>(url);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId)
        {
            pageId = string.IsNullOrEmpty(pageId.Trim()) ? "" : $"&{pageId}";
            var url = $"air/offers/?offer_request_id={offersRequestId}{pageId}";
            return await RetrievePaginatedContent<Offer>(url);        
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, int limit = 50)
        {
            var url = $"air/offers/?offer_request_id={offersRequestId}&limit={limit}";
            return await RetrievePaginatedContent<Offer>(url);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId, int limit = 50)
        {
            pageId = string.IsNullOrEmpty(pageId.Trim()) ? "" : $"&{pageId}";
            var url = $"air/offers/?offer_request_id={offersRequestId}&limit={limit}{pageId}";
            return await RetrievePaginatedContent<Offer>(url);
        }
        */
    }
}