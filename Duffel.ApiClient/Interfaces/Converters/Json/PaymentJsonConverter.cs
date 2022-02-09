using System;
using System.Collections.Generic;
using System.Linq;
using Duffel.ApiClient.Interfaces.Models.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Duffel.ApiClient.Interfaces.Converters.Json
{
    public class PaymentJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is List<Payment> payments)
            {
                var items = payments.Select(payment =>
                {
                    var paymentType = "balance";
                    if (payment is ArcBspCash) paymentType = "cash";
                    
                    return $"{{\"type\":\"{paymentType}\",\"amount\":\"{payment.Amount}\",\"currency\":\"{payment.Currency}\"}}";
                });
                var payload = $"{string.Join(",", items)}";
                
                writer.WriteStartArray();
                writer.WriteRaw(payload);
                writer.WriteEndArray();
            }
            else if (value is Payment payment)
            {
                var paymentType = "balance";
                if (payment is ArcBspCash) paymentType = "cash";
                    
                writer.WriteRawValue($"{{\"type\":\"{paymentType}\",\"amount\":\"{payment.Amount}\",\"currency\":\"{payment.Currency}\"}}");
            }
            else
            {
                writer.WriteValue("[]");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var paymentType = (string)jo["type"]!;
            Payment result;
            
            switch(paymentType?.ToLower())
            {
                case "balance":
                    result = new Balance();
                    break;
                
                case "arc_bsp_cash":
                    result = new ArcBspCash();
                    break;

                default:
                    throw new NotImplementedException($"{paymentType} is not a recognised payment type.");
            };
            
            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Payment).IsAssignableFrom(objectType);
        }
    }
}