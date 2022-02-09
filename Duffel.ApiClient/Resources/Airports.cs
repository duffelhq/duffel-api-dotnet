using System.Net.Http;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public class Airports : Resource<Airport>
    {
        public Airports(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airports";
    }
}