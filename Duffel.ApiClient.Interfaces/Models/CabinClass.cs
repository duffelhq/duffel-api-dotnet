using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum CabinClass
    {
        Any,
        Economy,
        [EnumMember(Value = "premium_economy")] PremiumEconomy,
        First,
        Business
    }
}