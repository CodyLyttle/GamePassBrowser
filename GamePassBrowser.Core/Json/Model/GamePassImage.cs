using System;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    public class GamePassImage
    {
        [JsonPropertyName("URI")]
        public Uri Uri { get; set; }

        [JsonPropertyName("Width")] 
        public int Width { get; set; }

        [JsonPropertyName("Height")] 
        public int Height { get; set; }
    }
}