using System.Net.Http;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public class Aircraft : Resource<Models.Aircraft>
    {
        public Aircraft(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "aircraft";
    }
}