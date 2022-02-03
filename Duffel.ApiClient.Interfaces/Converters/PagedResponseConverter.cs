using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Interfaces;
using Duffel.ApiClient.Interfaces.Exceptions;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class PagedResponseConverter
    {
        public static DuffelResponsePage<IEnumerable<T>> Deserialize<T>(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<IEnumerable<T>>>(payload);
            
            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }
            
            return new DuffelResponsePage<IEnumerable<T>>(
                wrappedResponse.Data,
                wrappedResponse.Metadata.Before,
                wrappedResponse.Metadata.After,
                wrappedResponse.Metadata.Limit.Value);
        }
        
    }
}