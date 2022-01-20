using System.ComponentModel;
using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum PassengerType
    {
        Adult,
        Child,
        
        [EnumMember(Value = "infant_without_seat")]
        Infant
    }
}