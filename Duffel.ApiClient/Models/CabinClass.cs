using System.Runtime.Serialization;

namespace Duffel.ApiClient.Models
{
    public enum CabinClass
    {
        Any,
        [EnumMember(Value = "economy")] Economy,
        [EnumMember(Value = "premium_economy")] PremiumEconomy,
        [EnumMember(Value = "first")] First,
        [EnumMember(Value = "business")] Business
    }
}