using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class SingleOfferResponseConverter
    {
        public static Offer Deserialize(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelDataWrapper<Offer>>(payload);
            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);
            
        }
    }
}