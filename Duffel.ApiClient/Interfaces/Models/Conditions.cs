using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    /// TODO: should this be a dictionary?
    public class Conditions
    {
        /// <summary>
        /// Whether the whole offer can be changed before the departure of the first slice.
        /// If all of the slices on the offer can be changed then the allowed property will be true
        /// If the airline hasn't provided any information about whether this offer can be changed then this property will be null.
        /// </summary>
        [JsonProperty("refund_before_departure")]
        public Condition RefundBeforeDeparture { get; set; }

        /// <summary>
        /// Whether the whole offer can be refunded before the departure of the first slice
        /// If all of the slices on the offer can be refunded then the allowed property will be true and information will be provided about any penalties.
        /// If any of the slices on the offer can't be refunded then the allowed property will be false.
        /// If the airline hasn't provided any information about whether this offer can be refunded then this property will be null.
        /// </summary>
        [JsonProperty("change_before_departure")]
        public Condition ChangeBeforeDeparture { get; set; }
    }

    public class Condition
    {
        [JsonProperty("allowed")] public bool Allowed { get; set; }
        
        [JsonProperty("penalty_currency")] public string PenaltyCurrency { get; set; }

        [JsonProperty("penalty_amount")] public string PenaltyAmount { get; set; }
    }
}