using System.ComponentModel;
using System.Text.Json.Serialization;
using GamePassBrowser.Core.Json.Converter;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassLanguageSupportInfo
    {
        [JsonPropertyName("InterfaceLanguageSupport")]
        [JsonConverter(typeof(JsonIntToBoolConverter))]
        public bool HasInterfaceSupport { get; set; }

        [JsonPropertyName("GamePlayAudioLanguageSupport")]
        [JsonConverter(typeof(JsonIntToBoolConverter))]
        public bool HasGamePlaySupport { get; set; }

        [JsonPropertyName("SubtitlesLanguageSupport")]
        [JsonConverter(typeof(JsonIntToBoolConverter))]
        public bool HasSubtitleSupport { get; set; }
    }
}