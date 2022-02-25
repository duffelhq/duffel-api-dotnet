using Duffel.ApiClient.Resources;

namespace Duffel.ApiClient
{
    public interface IDuffelApiClient
    {
         Aircraft Aircraft { get; }
         Airlines Airlines { get; }
         Airports Airports { get; }
         Offers Offers { get; }
         OfferRequests OfferRequests { get; }
         Orders Orders { get; }
         SeatMaps SeatMaps { get; }
         Payments Payments { get; }
         OrderChangeRequests OrderChangeRequests { get; }
         OrderChanges OrderChanges { get; }
         OrderChangeOffers OrderChangeOffers { get; }
         OrderCancellations OrderCancellations { get; }
        
    }
}