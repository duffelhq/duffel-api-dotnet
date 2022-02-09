using System.Runtime.Serialization;

namespace Duffel.ApiClient.Models
{
    public enum OrderType
    {
        [EnumMember(Value = "instant")]
        Instant,
        
        [EnumMember(Value = "hold")]
        Hold
    }
}