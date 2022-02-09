using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum OrderType
    {
        [EnumMember(Value = "instant")]
        Instant,
        
        [EnumMember(Value = "hold")]
        Hold
    }
}