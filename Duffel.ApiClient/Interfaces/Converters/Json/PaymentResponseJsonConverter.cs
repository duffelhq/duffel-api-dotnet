using System;
using Duffel.ApiClient.Interfaces.Models.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Duffel.ApiClient.Interfaces.Converters.Json
{
    public class PaymentResponseJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var paymentType = (string)jo["type"]!;
            
            switch (paymentType.ToLower())
            {
                case "balance":
                    var balance = new PaymentResponse();
                    serializer.Populate(jo.CreateReader(), balance);
                    return balance;
                
                case "arc_bsp_cash":
                    var cash = new PaymentResponse();
                    serializer.Populate(jo.CreateReader(), cash);
                    return cash;
                
                default:
                    throw new NotImplementedException($"Payment type: {paymentType} is not supported!");
            }
            
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}