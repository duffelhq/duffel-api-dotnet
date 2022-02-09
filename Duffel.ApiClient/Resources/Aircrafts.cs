using System.Net.Http;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public class Aircrafts : Resource<Aircraft>
    {
        public Aircrafts(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "aircraft";
    }
}