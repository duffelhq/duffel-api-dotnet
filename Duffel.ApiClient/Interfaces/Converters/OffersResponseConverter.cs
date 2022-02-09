using System.Linq;
using Duffel.ApiClient.Interfaces.Exceptions;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Interfaces.Converters
{
    public static class OffersResponseConverter
    {
        /// <summary>
        /// Serializes <see cref="OffersRequest"/> into a JSON string that can be consumed by
        /// Duffel API
        /// </summary>
        public static string Serialize(OffersRequest request)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            return JsonConvert.SerializeObject(new DuffelDataWrapper<OffersRequest>(request), Formatting.None, settings);
        }
        
        public static OffersResponse Deserialize(string payload)
        {
            var wrappedResponse = 
                JsonConvert.DeserializeObject<DuffelResponseWrapper<OffersResponse>>(
                    payload);

            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null ,payload);            
        }
    }
}