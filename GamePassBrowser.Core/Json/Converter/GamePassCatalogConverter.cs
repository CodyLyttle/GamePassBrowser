using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Text.Json;
using System.Xml.Linq;
using GamePassBrowser.Core.Json.Model;

namespace GamePassBrowser.Core.Json.Converter
{
    internal class GamePassCatalogConverter : ReadOnlyJsonConverter<GamePassCatalog>
    {
        // TODO: Run performance profiler and decide whether this needs refactoring
        public override GamePassCatalog Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            GamePassCatalogInfo catalogInfo = new()
            {
                SigilID = ReadUntilNextContent(ref reader).GetGuid(),
                Title = ReadUntilNextContent(ref reader).GetString(),
                Description = ReadUntilNextContent(ref reader).GetString(),
                RequiresShuffle = Convert.ToBoolean(ReadUntilNextContent(ref reader).GetString()),
                ImageUrl = new Uri(ReadUntilNextContent(ref reader).GetString() ?? string.Empty)
            };

            List<string> ids = new();

            try
            {
                while (true)
                {
                    ids.Add(ReadUntilNextContent(ref reader).GetString());
                }
            }
            catch (EndOfStreamException)
            {
                // Final 
            }

            return new GamePassCatalog
            {
                Info = catalogInfo,
                ProductIDs = ids.ToArray()
            };
        }

        private static ref Utf8JsonReader ReadUntilNextContent(ref Utf8JsonReader reader)
        {
            do
            {
                reader.Read();
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    throw new EndOfStreamException();
                }
            } while (reader.TokenType is JsonTokenType.StartArray 
                or JsonTokenType.StartObject
                or JsonTokenType.PropertyName
                or JsonTokenType.EndObject);

            return ref reader;
        }
    }
}