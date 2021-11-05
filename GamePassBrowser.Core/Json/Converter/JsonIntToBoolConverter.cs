using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamePassBrowser.Core.Json.Converter
{
    internal class JsonIntToBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Convert.ToBoolean(reader.GetByte());
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert.ToByte(value));
        }
    }
}