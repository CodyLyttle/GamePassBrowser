using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    // OMITTED PROPERTIES:
    // ConsoleComingSoonDate
    // ConsoleCrossGenSiblings
    // XboxConsoleGenCompatible
    // XboxTitleId
    internal class GamePassProduct
    {
        // ReSharper disable once StringLiteralTypo
        [JsonPropertyName("ConsolePlatformPreinstallable")]
        public bool IsConsolePlatformPreInstallable { get; set; }

        [JsonPropertyName("ApproximateSizeInBytes")]
        public long? ApproximateSizeInBytes { get; set; }

        [JsonPropertyName("Attributes")] 
        public GamePassPlatformProperty[] PlatformInfo { get; set; }

        [JsonPropertyName("ProductTitle")] 
        public string ProductTitle { get; set; }

        [JsonPropertyName("ProductDescription")]
        public string ProductDescription { get; set; }

        [JsonPropertyName("ProductType")] 
        public string ProductType { get; set; }

        [JsonPropertyName("DeveloperName")] 
        public string DeveloperName { get; set; }

        [JsonPropertyName("PublisherName")] 
        public string PublisherName { get; set; }

        [JsonPropertyName("ReviewScore")] 
        public float ReviewScore { get; set; }

        [JsonPropertyName("ReviewCount")] 
        public int ReviewCount { get; set; }

        [JsonPropertyName("ImageTile")] 
        public GamePassImage ImageTile { get; set; }

        [JsonPropertyName("ImageHero")] 
        public GamePassImage ImageHero { get; set; }

        [JsonPropertyName("ImagePoster")] 
        public GamePassImage ImagePoster { get; set; }

        [JsonPropertyName("Screenshots")]
        public GamePassImage[] Screenshots { get; set; }

        [JsonPropertyName("Trailers")] 
        public GamePassTrailer[] Trailers { get; set; }

        [JsonPropertyName("Categories")] 
        public string[] Categories { get; set; }

        [JsonPropertyName("AllowedPlatforms")] 
        public string[] AllowedPlatforms { get; set; }

        [JsonPropertyName("ContentRating")] 
        public GamePassContentRating GamePassContentRating { get; set; }

        [JsonPropertyName("XPAEnabled")] 
        public bool XpaEnabled { get; set; }

        [JsonPropertyName("UltimateComingSoonDate")]
        public DateTime? UltimateComingSoonDate { get; set; }

        [JsonPropertyName("IsEAPlay")] 
        public bool IsEaPlay { get; set; }

        [JsonPropertyName("RequiresXboxLiveGold")]
        public bool RequiresXboxLiveGold { get; set; }

        [JsonPropertyName("InitialAddOnProducts")]
        public GamePassAddOnProduct[] InitialAddOnProducts { get; set; }

        [JsonPropertyName("RemainingAddOnProductStoreIds")]
        public string[] RemainingAddOnProductStoreIds { get; set; }

        [JsonPropertyName("Price")] 
        public GamePassPrice Price { get; set; }

        [JsonPropertyName("LanguageSupport")] 
        public  Dictionary<string, GamePassLanguageSupportInfo> LanguageSupport { get; set; }

        [JsonPropertyName("AccessibilitySupport")]
        public GamePassAccessibilitySupport GamePassAccessibilitySupport { get; set; }

        [JsonPropertyName("StoreId")]
        public string StoreId { get; set; }
    }
}