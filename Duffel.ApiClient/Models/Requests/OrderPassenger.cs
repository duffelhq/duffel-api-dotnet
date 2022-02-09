using System.Collections.Generic;
using Duffel.ApiClient.Models.IdentityDocuments;
using Newtonsoft.Json;
using IdentityDocumentJsonConverter = Duffel.ApiClient.Converters.Json.IdentityDocumentJsonConverter;

namespace Duffel.ApiClient.Models.Requests
{
    public class OrderPassenger
    {
        /// <summary>
        /// The type of the passenger, See: <see cref="PassengerType"/>
        /// </summary>
        [JsonProperty("type")]
        public PassengerType PassengerType { get; set; }
        
        /// <summary>
        /// The passenger's title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// The passenger's phone number in E.164 (international) format
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Infant passengers, with an age of 0 or 1, must be associated with an adult passenger. This field should be used to make this association. It should contain the id of the infant passenger as returned in the <see cref="OffersRequest"/>.
        /// </summary>
        [JsonProperty("infant_passenger_id")]
        public string InfantPassengerId { get; set; }
        
        /// <summary>
        /// The passenger's identity documents. You may only provide one identity document per passenger. The identity document's type must be included in the offer's allowed_passenger_identity_document_types. If the offer's passenger_identity_documents_required is set to true, then an identity document must be provided.
        /// </summary>
        [JsonProperty("identity_documents")]
        [JsonConverter(typeof(IdentityDocumentJsonConverter))]
        public IEnumerable<IdentityDocument> IdentityDocuments { get; set; }
        
        /// <summary>
        /// The id of the passenger, returned when the <see cref="OffersRequest"/> was created
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// The passenger's gender
        /// </summary>
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        
        /// <summary>
        /// The passenger's given name. Only space, -, ', and letters from the ASCII, Latin-1 Supplement and Latin Extended-A (with the exceptions of Æ, æ, Ĳ, ĳ, Œ, œ, Þ, and ð) Unicode charts are accepted. All other characters will result in a validation error. The minimum length is 1 character, and the maximum is 20 characters.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        
        /// <summary>
        /// The passenger's family name. Only space, -, ', and letters from the ASCII, Latin-1 Supplement and Latin Extended-A (with the exceptions of Æ, æ, Ĳ, ĳ, Œ, œ, Þ, and ð) Unicode charts are accepted. All other characters will result in a validation error. The minimum length is 1 character, and the maximum is 20 characters.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        
        /// <summary>
        /// The passenger's email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        
        /// <summary>
        /// The passenger's date of birth
        /// </summary>
        [JsonProperty("born_on")]
        public string BornOn { get; set; }
    }
}