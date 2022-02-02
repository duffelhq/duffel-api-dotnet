using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Converters
{
    public static class OrderConverter
    {
        public static string Serialize(OrderRequest request)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var wrapped = new DuffelDataWrapper<OrderRequest>(request);
            return JsonConvert.SerializeObject(wrapped, Formatting.None, settings);
        }

        public static Order Deserialize(string payload)
        {
            var wrapperResponse =
                JsonConvert.DeserializeObject<DuffelResponseWrapper<Order>>(payload);
            return (wrapperResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);
        }
    }
}