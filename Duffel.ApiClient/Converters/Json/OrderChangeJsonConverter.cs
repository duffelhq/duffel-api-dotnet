using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Converters.Json
{
    public class SliceListToDictConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<string> sliceIds)
            {
                var items = sliceIds.Select(sliceId =>
                {
                        return $"{{\"slice_id\":\"{sliceId}\"}}";
                });
                var payload = $"{string.Join(",", items)}";
                writer.WriteStartArray();
                writer.WriteRaw(payload);
                writer.WriteEndArray();
            }
            else
            {
                throw new NotImplementedException();   
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(OrderChangeRequest).IsAssignableFrom(objectType);
        }
    }
}