using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models.Requests
{
    internal class SelectedOrderChangeOffer
    {
        [JsonProperty("selected_order_change_offer")]
        public string Id { get; set; }
    }
}