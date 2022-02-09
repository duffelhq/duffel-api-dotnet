using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum Gender
    {
        [EnumMember(Value = "m")]
        Male,
        
        [EnumMember(Value = "f")]
        Female
    }
}