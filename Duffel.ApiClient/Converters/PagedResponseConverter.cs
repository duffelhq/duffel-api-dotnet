using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Exceptions;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class PagedResponseConverter
    {
        public static DuffelResponsePage<IEnumerable<T>> Deserialize<T>(string payload, HttpStatusCode statusCode)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<IEnumerable<T>>>(payload);
            
            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors, statusCode);
            }
            
            return new DuffelResponsePage<IEnumerable<T>>(
                wrappedResponse.Data,
                wrappedResponse.Metadata.Before,
                wrappedResponse.Metadata.After,
                wrappedResponse.Metadata.Limit.Value);
        }
    }
}