using Newtonsoft.Json;

namespace Duffel.ApiClient.Interfaces.Models
{
    public class Place
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("icao_code")]
        public string IcaoCode { get; set; }
        
        [JsonProperty("iata_country_code")]
        public string IataCountryCode { get; set; }
        
        [JsonProperty("iata_code")]
        public string IataCode { get; set; }
        
        [JsonProperty("iata_city_code")]
        public string IataCityCode { get; set; }
        
        [JsonProperty("city_name")]
        public string CityName { get; set; }
        
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }
        
        [JsonProperty("name")]
        public string PlaceName { get; set; }
        
        [JsonProperty("longitude")]
        public float? Longitude { get; set; }
        
        [JsonProperty("latitude")]
        public float? Latitude { get; set; }
        
    }
}