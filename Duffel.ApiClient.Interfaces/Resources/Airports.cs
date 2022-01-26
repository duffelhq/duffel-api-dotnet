using System.Net.Http;
using Duffel.ApiClient.Interfaces.Models;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class Airports : Resource<Airport>
    {
        public Airports(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airports";
    }
}