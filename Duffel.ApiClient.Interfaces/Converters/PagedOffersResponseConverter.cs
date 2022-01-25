using System.Collections.Generic;
using Duffel.ApiClient.Interfaces;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class PagedOffersResponseConverter
    {
        public static DuffelResponsePage<IEnumerable<Offer>> Deserialize(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<IEnumerable<Offer>>>(payload);
            return new DuffelResponsePage<IEnumerable<Offer>>(
                wrappedResponse.Data,
                wrappedResponse.Metadata.Before,
                wrappedResponse.Metadata.After,
                wrappedResponse.Metadata.Limit.Value);
        }
        
    }
}