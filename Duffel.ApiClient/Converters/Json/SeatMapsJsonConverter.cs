using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Exceptions;
using Duffel.ApiClient.Models;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters.Json
{
    public static class SeatMapsJsonConverter
    {
        public static IEnumerable<SeatMap> DeserializeSeatsMap(string payload)
        {
            var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<IEnumerable<SeatMap>>>(payload);
            if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
            {
                throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors);
            }

            return (wrappedResponse?.Data ?? null) ?? throw new ApiDeserializationException(null ,payload);
        }
    }
}