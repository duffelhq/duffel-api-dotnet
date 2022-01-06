using Duffel.ApiClient.Models;
using Duffel.ApiClient.Models.Requests;
using Duffel.ApiClient.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Converters
{
    public static class OffersConverter
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
            var unwrappedResponse = 
                JsonConvert.DeserializeObject<DuffelDataWrapper<OffersResponse>>(
                    payload, 
                    new OffersResponseJsonConverter());
            
            return unwrappedResponse.Data;            
        }
    }
}