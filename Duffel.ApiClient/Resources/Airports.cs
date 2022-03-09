using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public interface IAirports
    {
        Task<Airport> Get(string id);
        Task<DuffelResponsePage<IEnumerable<Airport>>> List(int limit = 50, string before = "", string after = "");
        Task<IEnumerable<Airport>> GetAll();
    }

    public class Airports : Resource<Airport>, IAirports
    {
        public Airports(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "airports";
    }
}