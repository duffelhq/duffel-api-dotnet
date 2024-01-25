using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Models;

namespace Duffel.ApiClient.Resources
{
    public interface ILoyaltyProgrammes
    {
        Task<LoyaltyProgramme> Get(string id);
        Task<DuffelResponsePage<IEnumerable<LoyaltyProgramme>>> List(int limit = 50, string before = "", string after = "");
        Task<IEnumerable<LoyaltyProgramme>> GetAll();
    }

    public class LoyaltyProgrammes : Resource<LoyaltyProgramme>, ILoyaltyProgrammes
    {
        public LoyaltyProgrammes(HttpClient httpClient) : base(httpClient)
        {
        }

        protected override string ResourceName => "loyalty_programmes";
    }
}
