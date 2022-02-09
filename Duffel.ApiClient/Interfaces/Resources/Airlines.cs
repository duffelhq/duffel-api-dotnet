using System.Net.Http;
using Duffel.ApiClient.Interfaces.Models;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public class Airlines : Resource<Airline>
    {
        public Airlines(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airlines";
    }
}