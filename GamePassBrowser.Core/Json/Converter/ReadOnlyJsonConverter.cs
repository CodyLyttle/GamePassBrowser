using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Converter
{
    internal abstract class ReadOnlyJsonConverter<T> : JsonConverter<T>
    {
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException("This converter does not support write functionality");
        }
    }
}