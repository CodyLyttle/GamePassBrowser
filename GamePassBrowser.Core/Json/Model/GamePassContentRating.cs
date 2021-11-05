using System;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    // OMITTED PROPERTIES:
    // InteractiveElements
    internal class GamePassContentRating
    {
        [JsonPropertyName("RatingSystem")] 
        public string RatingSystemShortName { get; set; }

        [JsonPropertyName("RatingSystemLongName")]
        public string RatingSystemLongName { get; set; }

        [JsonPropertyName("RatingSystemUrl")] 
        public Uri RatingSystemUrl { get; set; }

        [JsonPropertyName("RatingId")] 
        public string RatingId { get; set; }

        [JsonPropertyName("RatingValue")] 
        public string RatingValue { get; set; }

        [JsonPropertyName("Description")] 
        public string Description { get; set; }

        [JsonPropertyName("RatingAge")] 
        public int RatingAge { get; set; }

        [JsonPropertyName("RatingValueLogoUrl")]
        public Uri RatingValueLogoUrl { get; set; }

        [JsonPropertyName("RatingDescriptors")]
        public string[] RatingDescriptors { get; set; }

        [JsonPropertyName("RatingDisclaimers")]
        public string[] RatingDisclaimers { get; set; }
    }
}