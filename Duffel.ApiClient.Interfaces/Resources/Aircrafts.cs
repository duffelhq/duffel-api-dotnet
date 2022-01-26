using System.Net.Http;
using Duffel.ApiClient.Interfaces.Models;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class Aircrafts : Resource<Aircraft>
    {
        public Aircrafts(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "aircraft";
    }
}