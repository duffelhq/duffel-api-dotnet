using Duffel.ApiClient.Converters;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Converters
{
    public static class SingleItemResponseConverter
    {
        public static T Deserialize<T>(string payload) where T: class
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelDataWrapper<T>>(payload);
            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);
            
        }
    }
}