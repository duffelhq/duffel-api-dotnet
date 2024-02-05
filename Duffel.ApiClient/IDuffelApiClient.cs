using Duffel.ApiClient.Resources;

namespace Duffel.ApiClient
{
    public interface IDuffelApiClient
    {
         IAircraft Aircraft { get; }
         IAirlines Airlines { get; }
         IAirports Airports { get; }
         ILoyaltyProgrammes LoyaltyProgrammes { get; }
         IOffers Offers { get; }
         IOfferRequests OfferRequests { get; }
         IOrders Orders { get; }
         ISeatMaps SeatMaps { get; }
         IPayments Payments { get; }
         IOrderChangeRequests OrderChangeRequests { get; }
         IOrderChanges OrderChanges { get; }
         IOrderChangeOffers OrderChangeOffers { get; }
         IOrderCancellations OrderCancellations { get; }
    }
}
