using System;
using System.Net.Http;
using System.Reflection;
using Duffel.ApiClient.Resources;

namespace Duffel.ApiClient
{
    public class DuffelApiClient : IDuffelApiClient
    {
        private readonly HttpClient _httpClient;
        
        public IAirlines Airlines { get; set; }
        public IAirports Airports { get; set; }
        public IAircraft Aircraft { get; set; }
        public IOfferRequests OfferRequests { get; set; }
        public IOffers Offers { get; set; }
        public IOrders Orders { get; set; }
        public ISeatMaps SeatMaps { get; set; }
        public IPayments Payments { get; set; }
        public IOrderChangeRequests OrderChangeRequests { get; set; }
        public IOrderChanges OrderChanges { get; set; }
        public IOrderChangeOffers OrderChangeOffers { get; set; }
        public IOrderCancellations OrderCancellations { get; set; }
        
        public DuffelApiClient(string accessToken, bool production = false)
        {
            _httpClient = new HttpClient();
            Initialize(accessToken, production);
        }
        
        public DuffelApiClient(HttpClient httpClient, string accessToken, bool production = false)
        {
            _httpClient = httpClient;
            Initialize(accessToken, production);
        }

        private void Initialize(string accessToken, bool production)
        {
            var executingAssemblyName = Assembly.GetExecutingAssembly().GetName();
            _httpClient.BaseAddress =
                production ? new Uri("https://api.duffel.com") : new Uri("https://api.staging.duffel.com");

            _httpClient.DefaultRequestHeaders.Add("User-Agent",
                $"Duffel/beta {executingAssemblyName.Name}/{executingAssemblyName.Version}");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Duffel-Version", "beta");

            //httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip");

            Airlines = new Airlines(_httpClient);
            Airports = new Airports(_httpClient);
            Aircraft = new Aircraft(_httpClient);
            OfferRequests = new OfferRequests(_httpClient);
            Offers = new Offers(_httpClient);
            Orders = new Orders(_httpClient);
            SeatMaps = new SeatMaps(_httpClient);
            Payments = new Payments(_httpClient);
            OrderChangeRequests = new OrderChangeRequests(_httpClient);
            OrderChanges = new OrderChanges(_httpClient);
            OrderChangeOffers = new OrderChangeOffers(_httpClient);
            OrderCancellations = new OrderCancellations(_httpClient);
        }
    }
}