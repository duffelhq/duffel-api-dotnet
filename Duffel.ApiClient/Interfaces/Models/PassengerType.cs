using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum PassengerType
    {
        [EnumMember(Value = "adult")]
        Adult,
        
        [EnumMember(Value = "child")]
        Child,
        
        [EnumMember(Value = "infant_without_seat")]
        Infant
    }
}