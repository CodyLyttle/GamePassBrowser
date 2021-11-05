using System;
using System.Text.Json.Serialization;
using GamePassBrowser.Core.Json.Converter;

namespace GamePassBrowser.Core.Json.Model
{
    [JsonConverter(typeof(GamePassCatalogConverter))]
    public class GamePassCatalog
    {
        public GamePassCatalogInfo Info { get; set; }
        
        [JsonPropertyName("Products")]
        public string[] ProductIDs { get; set; }
        
        // Implemented equality members to satisfy unit test.
        public override int GetHashCode()
        {
            return HashCode.Combine(Info, ProductIDs);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GamePassCatalog)obj);
        }

        protected bool Equals(GamePassCatalog other)
        {
            if (ProductIDs.Length != other.ProductIDs.Length)
                return false;

            for (int i = 0; i < ProductIDs.Length; i++)
            {
                if (ProductIDs[i] != other.ProductIDs[i])
                    return false;
            }

            return Info.SigilID == other.Info.SigilID
                   && Info.Title == other.Info.Title 
                   && Info.Description == other.Info.Description 
                   && Info.RequiresShuffle == other.Info.RequiresShuffle 
                   && Info.ImageUrl.Equals(other.Info.ImageUrl);
        }
    }
}