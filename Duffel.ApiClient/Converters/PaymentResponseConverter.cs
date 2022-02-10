using Duffel.ApiClient.Models.Requests;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Duffel.ApiClient.Converters
{
    public static class PaymentResponseConverter
    {
        public static string Serialize(PaymentRequest paymentRequest)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter {NamingStrategy = new SnakeCaseNamingStrategy()});
            return  JsonConvert.SerializeObject(new DuffelDataWrapper<PaymentRequest>(paymentRequest), Formatting.None, settings);
        }
    }
}