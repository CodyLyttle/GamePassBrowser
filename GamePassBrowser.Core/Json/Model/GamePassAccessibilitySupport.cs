using System;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassAccessibilitySupport
    {
        [JsonPropertyName("Uri")] 
        public Uri Uri { get; set; }

        [JsonPropertyName("GamePlay")] 
        public GamePassProperty GamePlayInfo { get; set; }

        [JsonPropertyName("Audio")] 
        public GamePassProperty AudioInfo { get; set; }

        [JsonPropertyName("Visual")] 
        public GamePassProperty VisualInfo { get; set; }

        [JsonPropertyName("Input")] 
        public GamePassProperty InputInfo { get; set; }
    }
}