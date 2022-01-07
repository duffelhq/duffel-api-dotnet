using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Responses.Offers
{
    /// TODO: should this be a dictionary?
    public class Conditions
    {
        [JsonProperty("refund_before_departure")]
        public Condition RefundBeforeDeparture { get; set; }

        [JsonProperty("change_before_departure")]
        public Condition ChangeBeforeDeparture { get; set; }
    }

    public class Condition
    {
        /// TODO: I have my doubts here. We only populate a property in <see cref="Conditions"/>  if it is allowed.
        /// If it is not allowed it is set to null, so the allowed seems never to be set to false
        /// Except... https://duffel.com/docs/guides/offer-and-order-conditions#what-information-is-available-in-the-duffel-api
        [JsonProperty("allowed")]
        public bool Allowed { get; set; }
        
        [JsonProperty("penalty_currency")] public string PenaltyCurrency { get; set; }

        [JsonProperty("penalty_amount")] public string PenaltyAmount { get; set; }
    }
}