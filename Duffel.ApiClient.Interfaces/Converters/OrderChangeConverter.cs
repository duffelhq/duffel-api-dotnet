using Duffel.ApiClient.Converters;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Interfaces.Converters
{
    public class OrderChangeConverter
    {
        public static string Serialize(OrderChangeRequest request)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            var wrapped = new DuffelDataWrapper<OrderChangeRequest>(request);
            return JsonConvert.SerializeObject(wrapped, Formatting.None, settings);
            
            
        }
        
    }
}