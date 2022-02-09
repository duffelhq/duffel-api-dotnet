using System.Linq;
using Duffel.ApiClient.Exceptions;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Converters
{
    public static class OrderCancellationConverter
    {
        public static string Serialize(OrderCancellationRequest request)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var wrapped = new DuffelDataWrapper<OrderCancellationRequest>(request);
            return JsonConvert.SerializeObject(wrapped, Formatting.None, settings);
        }
        
        public static OrderCancellation Deserialize(string payload)
        {
            var wrappedResponse = 
                JsonConvert.DeserializeObject<DuffelResponseWrapper<OrderCancellation>>(
                    payload);

            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null ,payload);
        }
    }
}