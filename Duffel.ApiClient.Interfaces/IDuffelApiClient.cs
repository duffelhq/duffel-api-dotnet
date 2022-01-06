using System.Threading.Tasks;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces
{
    public interface IDuffelApiClient
    {
        Task<OffersResponse> CreateOffersRequest(OffersRequest request);
    }
}