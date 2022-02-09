using System.Linq;
using Duffel.ApiClient.Interfaces.Exceptions;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Interfaces.Converters
{
    public static class OrderChangeConverter
    {
        public static string Serialize(OrderChangeRequest request)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var wrapped = new DuffelDataWrapper<OrderChangeRequest>(request);
            return JsonConvert.SerializeObject(wrapped, Formatting.None, settings);
        }

        public static OrderChangeResponse Deserialize(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<OrderChangeResponse>>(payload);
            
            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }
            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);

        }
    }
}