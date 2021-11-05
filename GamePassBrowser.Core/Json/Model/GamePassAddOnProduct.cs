using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassAddOnProduct
    {
        [JsonPropertyName("ProductTitle")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("DeveloperName")]
        public string DeveloperName { get; set; }

        [JsonPropertyName("PublisherName")]
        public string PublisherName { get; set; }

        [JsonPropertyName("ImageTile")]
        public GamePassImage GamePassImageTile { get; set; }

        [JsonPropertyName("ImageHero")]
        public GamePassImage GamePassImageHero { get; set; }

        [JsonPropertyName("ImagePoster")]
        public GamePassImage GamePassImagePoster { get; set; }

        [JsonPropertyName("ApproximatePrice")]
        public GamePassPrice ApproximateGamePassPrice { get; set; }

        [JsonPropertyName("StoreId")]
        public string StoreId { get; set; }
    }
}