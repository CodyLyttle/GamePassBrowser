using System.Text.Json.Serialization;
using GamePassBrowser.Core.Json.Converter;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassProperty
    {
        [JsonPropertyName("Localization")] 
        public string Name { get; set; }

        [JsonPropertyName("Value")]
        [JsonConverter(typeof(GamePassValueToBoolConverter))]
        public bool IsSupported { get; set; }
    }
}