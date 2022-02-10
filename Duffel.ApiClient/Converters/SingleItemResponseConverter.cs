using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Duffel.ApiClient.Exceptions;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters
{
    public static class SingleItemResponseConverter
    {
        public static async Task<T> GetAndDeserialize<T>(HttpResponseMessage response) where T : class
        {
            var payload = await response.Content.ReadAsStringAsync();
            return Deserialize<T>(payload, response.StatusCode);
        }

        public static T Deserialize<T>(string payload, HttpStatusCode statusCode) where T : class
        {
            try
            {
                var wrappedResponse = JsonConvert.DeserializeObject<DuffelResponseWrapper<T>>(payload);

                if (wrappedResponse != null && wrappedResponse.Errors != null && wrappedResponse.Errors.Any())
                {
                    throw new ApiException(wrappedResponse.Metadata, wrappedResponse.Errors, statusCode);
                }

                return (wrappedResponse?.Data ?? null) ??
                       throw new ApiDeserializationException(null, payload, statusCode);
            }
            catch (Exception e)
            {
                throw new ApiDeserializationException(e);
            }
        }
    }
}