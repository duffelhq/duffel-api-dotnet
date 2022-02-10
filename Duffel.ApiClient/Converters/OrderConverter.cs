using Duffel.ApiClient.Models.Requests;
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

        public static string SerializeMetadata(OrderMetadata metadata)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var wrapped = new DuffelDataWrapper<OrderMetadata>(metadata);
            return JsonConvert.SerializeObject(wrapped, Formatting.None, settings);
        }
    }
}