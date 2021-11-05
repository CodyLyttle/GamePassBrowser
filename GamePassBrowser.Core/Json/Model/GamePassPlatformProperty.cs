using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    // TODO: Ignore attributes where name starts with Xb (xbox)
    // TODO: If LocalizedName is empty use Name instead
    public class GamePassPlatformProperty
    {
        [JsonPropertyName("Name")] 
        public string Name { get; set; }

        [JsonPropertyName("LocalizedName")] 
        public string LocalizedName { get; set; }

        [JsonPropertyName("ApplicablePlatforms")]
        public string[] ApplicablePlatforms { get; set; }
    }
}