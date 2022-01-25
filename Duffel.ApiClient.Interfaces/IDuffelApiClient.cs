using System.Collections.Generic;
using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces
{
    public interface IDuffelApiClient
    {
        Task<OffersResponse> CreateOffersRequest(OffersRequest request);
        
        Task<Offer> GetSingleOffer(string offerId);
        
        Task<DuffelResponsePage<IEnumerable<Offer>>> ListOffers(string offersRequestId, string pageId);
    }
}