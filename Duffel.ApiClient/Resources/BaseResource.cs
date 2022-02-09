using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PagedResponseConverter = Duffel.ApiClient.Converters.PagedResponseConverter;

namespace Duffel.ApiClient.Resources
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
        
        protected async Task<DuffelResponsePage<IEnumerable<T>>> RetrievePaginatedContent(string url)
        {
            var result = await _httpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return PagedResponseConverter.Deserialize<T>(content);
        }
    }
}