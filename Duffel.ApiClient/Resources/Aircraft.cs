using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public interface IAircraft
    {
        Task<Models.Aircraft> Get(string id);
        Task<DuffelResponsePage<IEnumerable<Models.Aircraft>>> List(int limit = 50, string before = "", string after = "");
        Task<IEnumerable<Models.Aircraft>> GetAll();
    }

    public class Aircraft : Resource<Models.Aircraft>, IAircraft
    {
        public Aircraft(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "aircraft";
    }
}