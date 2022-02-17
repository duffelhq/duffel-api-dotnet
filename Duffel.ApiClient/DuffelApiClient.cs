using System;
using System.Net.Http;
using System.Reflection;
using Duffel.ApiClient.Resources;

namespace Duffel.ApiClient
{
    public class DuffelApiClient : IDuffelApiClient
    {
        private readonly HttpClient _httpClient;
        
        public Airlines Airlines { get; set; }
        public Airports Airports { get; set; }
        public Aircrafts Aircrafts { get; set; }
        public OfferRequests OfferRequests { get; set; }
        public Offers Offers { get; set; }
        public Orders Orders { get; set; }
        public SeatMaps SeatMaps { get; set; }
        public Payments Payments { get; set; }
        public OrderChangeRequests OrderChangeRequests { get; set; }
        public OrderChanges OrderChanges { get; set; }
        public OrderChangeOffers OrderChangeOffers { get; set; }

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
            Aircrafts = new Aircrafts(_httpClient);
            OfferRequests = new OfferRequests(_httpClient);
            Offers = new Offers(_httpClient);
            Orders = new Orders(_httpClient);
            SeatMaps = new SeatMaps(_httpClient);
            Payments = new Payments(_httpClient);
            OrderChangeRequests = new OrderChangeRequests(_httpClient);
            OrderChanges = new OrderChanges(_httpClient);
            OrderChangeOffers = new OrderChangeOffers(_httpClient);
        }
    }
}