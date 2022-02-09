using System.Runtime.Serialization;

namespace Duffel.ApiClient.Models
{
    public enum Gender
    {
        [EnumMember(Value = "m")]
        Male,
        
        [EnumMember(Value = "f")]
        Female
    }
}