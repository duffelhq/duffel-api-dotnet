using System.Linq;
using System.Net;
using Duffel.ApiClient.Exceptions;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Converters
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
        
        public static OffersResponse Deserialize(string payload, HttpStatusCode statusCode = HttpStatusCode.Accepted)
        {
            var wrappedResponse = 
                JsonConvert.DeserializeObject<DuffelResponseWrapper<OffersResponse>>(
                    payload);

            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors, statusCode);
            }

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null ,payload);            
        }
    }
}