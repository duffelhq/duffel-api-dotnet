using System.Collections.Generic;
using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Models;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces
{
    public interface IDuffelApiClient
    {
        Task<OffersResponse> CreateOffersRequest(OffersRequest request);
        
        Task<Offer> GetSingleOffer(string offerId);
        
        Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId);
        Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId);
        Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, int limit);
        Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId, int limit);

        Task<DuffelResponsePage<IEnumerable<Airport>>> ListAirports();
        Task<DuffelResponsePage<IEnumerable<Airport>>> ListAirports(string pageId);
        Task<DuffelResponsePage<IEnumerable<Airport>>> ListAirports(int limit);
        Task<DuffelResponsePage<IEnumerable<Airport>>> ListAirports(string pageId, int limit);
        
        Task<DuffelResponsePage<IEnumerable<Airline>>> ListAirlines();
        Task<DuffelResponsePage<IEnumerable<Airline>>> ListAirlines(string pageId);
        Task<DuffelResponsePage<IEnumerable<Airline>>> ListAirlines(int limit);
        Task<DuffelResponsePage<IEnumerable<Airline>>> ListAirlines(string pageId, int limit);
    }
}