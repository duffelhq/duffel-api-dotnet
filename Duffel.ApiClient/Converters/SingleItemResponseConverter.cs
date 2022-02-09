using System.Linq;
using Duffel.ApiClient.Exceptions;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class SingleItemResponseConverter
    {
        public static T Deserialize<T>(string payload) where T: class
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<T>>(payload);
            
            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }
            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);
        }
    }
}