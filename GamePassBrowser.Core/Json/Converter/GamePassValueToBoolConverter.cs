using System;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Converter
{
    internal class GamePassValueToBoolConverter : ReadOnlyJsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.GetString() switch
            {
                "SetFalse" => false,
                "SetTrue" => true,
                _ => throw new InvalidEnumArgumentException()
            };
    }
}