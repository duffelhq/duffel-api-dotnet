using System.Runtime.Serialization;

namespace Duffel.ApiClient.Interfaces.Models
{
    public enum DocumentType
    {
        [EnumMember(Value = "electronic_ticket")]
        ElectronicTicket,
        
        [EnumMember(Value = "electronic_miscellaneous_document_associated")]
        ElectronicMiscellaneousDocumentAssociate,
        
        [EnumMember(Value = "electronic_miscellaneous_document_standalone")]
        ElectronicMiscellaneousDocumentStandalone
    }
}