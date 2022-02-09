using System;
using Duffel.ApiClient.Interfaces.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Duffel.ApiClient.Interfaces.Converters.Json
{
    internal class CabinClassJsonConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            switch (value)
            {
                case CabinClass.Any:
                    // API expects to skip the property for ANY cabin class
                    break;
                
                default:
                    // default behaviour 
                    base.WriteJson(writer, value, serializer);
                    break;
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return reader.Value == null ? CabinClass.Any : base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}