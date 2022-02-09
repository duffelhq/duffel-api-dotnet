using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Interfaces.Models.IdentityDocuments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Duffel.ApiClient.Interfaces.Converters.Json
{
    public class IdentityDocumentJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<IdentityDocument> identityDocuments)
            {
                var items = identityDocuments.Select(document =>
                {
                    if (document is Passport passport)
                    {
                        return $"{{\"type\":\"passport\",\"expires_on\":\"{passport.ExpiresOn}\",\"issuing_country_code\":\"{passport.IssuingCountryCode}\",\"unique_identifier\":\"{passport.UniqueIdentifier}\"}}";
                    }
                    throw new NotImplementedException($"Identity document of type: {document.GetType().ToString()} is not supported,");
                });
                var payload = $"{string.Join(",", items)}";
                writer.WriteStartArray();
                writer.WriteRaw(payload);
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteValue("[]");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var documentType = (string)jo["type"]!;
            IdentityDocument result;
            
            switch(documentType?.ToLower())
            {
                case "passport":
                    result = new Passport();
                    break;
                
                
                default:
                    throw new NotImplementedException($"{documentType} is not a recognised identity document type.");
            };
            
            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IdentityDocument).IsAssignableFrom(objectType);
        }
    }
}