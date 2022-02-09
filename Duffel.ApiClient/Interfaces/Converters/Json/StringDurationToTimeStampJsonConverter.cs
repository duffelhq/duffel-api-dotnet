using System;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Converters.Json
{
    internal class StringDurationToTimeStampJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value == null) return TimeSpan.Zero;
            var duration = reader.Value.ToString();
            return System.Xml.XmlConvert.ToTimeSpan(duration);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
