using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public interface IAirlines
    {
        Task<Airline> Get(string id);
        Task<DuffelResponsePage<IEnumerable<Airline>>> List(int limit = 50, string before = "", string after = "");
        Task<IEnumerable<Airline>> GetAll();
    }

    public class Airlines : Resource<Airline>, IAirlines
    {
        public Airlines(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airlines";
    }
}