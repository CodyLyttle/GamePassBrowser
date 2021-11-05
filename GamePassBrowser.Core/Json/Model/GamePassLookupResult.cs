using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Model
{
    internal class GamePassLookupResult
    {
        
        [JsonPropertyName("Products")] 
        public Dictionary<string, GamePassProduct> Products { get; set; }
        
        [JsonPropertyName("InvalidIds")] 
        public string[] InvalidIDs { get; set; }
    }
}