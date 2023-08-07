using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Models.IdentityDocuments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Duffel.ApiClient.Converters.Json
{
    public class IdentityDocumentJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<IdentityDocument> identityDocuments)
            {
                var items = identityDocuments.Select(document =>
                {
                    switch (document)
                    {
                        case Passport passport:
                            return $"{{\"type\":\"passport\",\"expires_on\":\"{passport.ExpiresOn}\",\"issuing_country_code\":\"{passport.IssuingCountryCode}\",\"unique_identifier\":\"{passport.UniqueIdentifier}\"}}";
                        case KnownTravelerNumber knownTravelerNumber:
                            return $"{{\"type\":\"known_traveler_number\",\"issuing_country_code\":\"{knownTravelerNumber.IssuingCountryCode}\",\"unique_identifier\":\"{knownTravelerNumber.UniqueIdentifier}\"}}";
                        case PassengerRedressNumber passengerRedressNumber:
                            return $"{{\"type\":\"passenger_redress_number\",\"issuing_country_code\":\"{passengerRedressNumber.IssuingCountryCode}\",\"unique_identifier\":\"{passengerRedressNumber.UniqueIdentifier}\"}}";
                        case TaxId taxId:
                            return $"{{\"type\":\"tax_id\",\"unique_identifier\":\"{taxId.UniqueIdentifier}\"}}";
                        default:
                            throw new NotImplementedException($"Identity document of type: {document.GetType().ToString()} is not supported,");
                    }
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
                case "known_traveler_number":
                    result = new KnownTravelerNumber();
                    break;
                case "passenger_redress_number":
                    result = new PassengerRedressNumber();
                    break;
                case "tax_id":
                    result = new TaxId();
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
