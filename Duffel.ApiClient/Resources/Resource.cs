using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Exceptions;

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
            return await SingleItemResponseConverter.GetAndDeserialize<T>(result);
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
            while (!string.IsNullOrEmpty(page.After))
            {
                page = await Get(limit: page.Limit, after: page.After, before: page.Before);
                result.AddRange(page.Data);
            }

            return result.AsEnumerable();    
        }

        protected abstract string ResourceName { get; }
        
    }
}