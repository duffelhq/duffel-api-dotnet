using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models.Responses
{
    public enum RefundType
    {
        [EnumMember(Value = "arc_bsp_cash")]
        ArcBspCash,
        
        [EnumMember(Value = "balance")]
        Balance,

        [EnumMember(Value = "card")]
        Card,
        
        [EnumMember(Value = "voucher")]
        Voucher,
        
        [EnumMember(Value = "awaiting_payment")]
        AwaitingPayment
    }
}