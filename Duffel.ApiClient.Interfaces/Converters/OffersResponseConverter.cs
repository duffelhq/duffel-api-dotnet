using System;
using Duffel.ApiClient.Interfaces.Models.Requests;
using Duffel.ApiClient.Interfaces.Models.Responses;
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
        
        public static OffersResponse Deserialize(string payload)
        {
            var wrappedResponse = 
                JsonConvert.DeserializeObject<DuffelDataWrapper<OffersResponse>>(
                    payload);

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null ,payload);            
        }
    }

    public static class SingleOfferResponseConverter
    {
        public static Offer Deserialize(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelDataWrapper<Offer>>(payload);
            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null, payload);
            
        }
    }

    public class ApiDeserializationException : Exception
    {
        public ApiDeserializationException(Exception? innerException, string payload = null!) 
            : base(innerException?.Message ?? "", innerException)
        {
            Payload = payload;
        }
        
        public string Payload { get; }
    }
}