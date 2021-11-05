using System;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    public class GamePassCatalogInfo
    {
        [JsonPropertyName("siglId")]
        public Guid SigilID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("requiresShuffling")]
        public bool RequiresShuffle { get; set; }
        [JsonPropertyName("imageUrl")]
        public Uri ImageUrl { get; set; }
    }
}