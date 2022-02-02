using System.Collections.Generic;
using Duffel.ApiClient.Interfaces.Converters;
using Duffel.ApiClient.Interfaces.Models.Payments;
using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    public class OrderRequest
    {
        /// <summary>
        /// The type of order. You can only use hold with offers where payment_requirements.requires_instant_payment is false.
        /// When booking an offer with type hold, do not specify payments or services keys.
        /// Possible values: <see cref="OrderType"/>
        /// </summary>
        [JsonProperty("type")]
        public OrderType OrderType { get; set; }
     
         /// <summary>
         /// The services you want to book along with the first selected offer. This key should be omitted when the order’s type is hold, as we do not support services for hold orders yet.
         /// </summary>
         [JsonProperty("services")]
         public IEnumerable<Service> Services { get; set; }

         /// <summary>
         /// The ids of the offers you want to book. You must specify an array containing exactly one selected offer.
         /// Note that you can only book one offer per offer request.
         /// </summary>
         [JsonProperty("selected_offers")]
         public IEnumerable<string> SelectedOffers { get; set; }
     
         /// <summary>
         /// The payment details to use to pay for the order. This key should be omitted when the order’s type is hold
         /// </summary>
         [JsonProperty("payments")]
         [JsonConverter(typeof(PaymentJsonConverter))]
         public IEnumerable<Payment> Payments { get; set; }

         /// <summary>
         /// The personal details of the passengers, expanding on the information initially provided when creating the offer request
         /// </summary>
         [JsonProperty("passengers")]
         public IEnumerable<OrderPassenger> Passengers { get; set; }
     
         /// <summary>
         /// Metadata contains a set of key-value pairs that you can attach to an object. It can be useful for storing additional information about the object, in a structured format. Duffel does not use this information. You should not store sensitive information in this field.
         /// The metadata is a collection of key-value pairs, both of which are strings. You can store a maximum of 50 key-value pairs, where each key has a maximum length of 40 characters and each value has a maximum length of 500 characters.
         /// Keys must only contain numbers, letters, dashes, or underscores.
         /// Example: {"payment_intent_id":"pit_00009htYpSCXrwaB9DnUm2"}
         /// </summary>
         [JsonProperty("metadata")]
         public IDictionary<string, string> Metadata { get; set; }
    }
}