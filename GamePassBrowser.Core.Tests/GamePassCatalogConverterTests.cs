using System;
using System.Text;
using System.Text.Json;
using GamePassBrowser.Core.Json.Converter;
using GamePassBrowser.Core.Json.Model;
using Xunit;

namespace GamePassBrowser.Core.Tests
{
    public class GamePassCatalogConverterTests
    {
        [Fact]
        public void Read_WithResponseContent_ReturnsValidGamePassCatalog()
        {
            GamePassCatalog expected = new()
            {
                Info = new GamePassCatalogInfo()
                {
                    SigilID = new Guid("fdd9e2a7-0fee-49f6-ad69-4354098401ff"),
                    Title = "All PC Games",
                    Description = "Explore every game included with Xbox Game Pass PC",
                    RequiresShuffle = true,
                    ImageUrl = new Uri(
                        "http://store-images.s-microsoft.com/image/global.47673.acentoprodimg.40520333-055e-420a-bd6e-39b85591ccd3.65c04579-754f-40be-a1f2-f0e983dba803")
                },

                ProductIDs = new[]
                {
                    "9ND0CG3LM22K",
                    "9NJWTJSVGVLJ",
                    "9NJDD0JGPP2Q"
                }
            };

            string jsonContent = "[{\"siglId\":\"" + expected.Info.SigilID +
                                 "\",\"title\":\"" + expected.Info.Title +
                                 "\",\"description\":\"" + expected.Info.Description +
                                 "\",\"requiresShuffling\":\"" + expected.Info.RequiresShuffle +
                                 "\",\"imageUrl\":\"" + expected.Info.ImageUrl +
                                 "\"},{\"id\":\"" + expected.ProductIDs[0] +
                                 "\"},{\"id\":\"" + expected.ProductIDs[1] +
                                 "\"},{\"id\":\"" + expected.ProductIDs[2] +
                                 "\"}]";

            Utf8JsonReader reader = new(Encoding.UTF8.GetBytes(jsonContent));
            GamePassCatalogConverter converter = new();
            JsonSerializerOptions jsonOptions = new(JsonSerializerDefaults.Web);
            GamePassCatalog actual = converter.Read(ref reader, typeof(GamePassCatalog), jsonOptions);

            Assert.True(expected.Equals(actual));
        }
    }
}