using System;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassTrailer
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("URI")]
        public Uri Uri { get; set; }

        [JsonPropertyName("PreviewImageURI")]
        public Uri PreviewImageUri { get; set; }
    }
}