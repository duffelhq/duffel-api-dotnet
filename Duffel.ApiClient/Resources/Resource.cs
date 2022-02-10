using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;

namespace Duffel.ApiClient.Resources
{
    public abstract class Resource<T> : BaseResource<T> where T: class
    {
        public Resource(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<T> Get(string id) 
        {
            var result = await HttpClient.GetAsync($"air/{ResourceName}/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return SingleItemResponseConverter.Deserialize<T>(content);
        }
        
        public async Task<DuffelResponsePage<IEnumerable<T>>> Get(int limit = 50, string before = "", string after = "")
        {
            return await RetrievePaginatedContent($"air/{ResourceName}?limit={limit}&{after}");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            List<T> result = new List<T>();
            var page = await Get(limit: 200);
            result.AddRange(page.Data);
            while (!string.IsNullOrEmpty(page.NextPage))
            {
                page = await Get(limit: page.Limit, after: page.NextPage, before: page.PreviousPage);
                result.AddRange(page.Data);
            }

            return result.AsEnumerable();    
        }

        protected abstract string ResourceName { get; }
        
    }
}