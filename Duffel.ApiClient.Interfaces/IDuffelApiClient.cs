using Duffel.ApiClient.Interfaces.Resources;

namespace Duffel.ApiClient.Interfaces
{
    public interface IDuffelApiClient
    {
         Aircrafts Aircrafts { get; }
         Airlines Airlines { get; }
         Airports Airports { get; }
         Offers Offers { get; }
         OfferRequests OfferRequests { get; }
         Orders Orders { get; }
         SeatMaps SeatMaps { get; }
         Payments Payments { get; }
         OrderChangeRequests OrderChangeRequests { get; }
        
    }
}