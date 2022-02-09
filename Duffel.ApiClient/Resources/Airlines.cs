using System.Net.Http;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public class Airlines : Resource<Airline>
    {
        public Airlines(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airlines";
    }
}