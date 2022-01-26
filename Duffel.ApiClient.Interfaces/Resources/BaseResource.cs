using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models.Responses;

namespace Duffel.ApiClient.Interfaces.Resources
{
    public abstract class BaseResource<T>
    {
        private readonly HttpClient _httpClient;

        public BaseResource(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        
        protected HttpClient HttpClient
        {
            get { return _httpClient; }
        }
        
        protected async Task<DuffelResponsePage<IEnumerable<T>>> RetrievePaginatedContent(string? url)
        {
            var result = await _httpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return PagedResponseConverter.Deserialize<T>(content);
        }
    }
}