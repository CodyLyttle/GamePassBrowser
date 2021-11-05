using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    public class GamePassPrice
    {
        [JsonPropertyName("MSRP")]
        public string Msrp { get; set; }

        [JsonPropertyName("SalePrice")]
        public string SalePrice { get; set; }

        [JsonPropertyName("IsFree")]
        public bool IsFree { get; set; }
    }
}