using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace VaccineAvailability.TelematikClient.Converters
{
    public class TelematikDateTimeConverter : JsonConverter<DateTime>
    {
        private const string LastDigitPattern = "[0]{1}$";

        private const string LastFourDigitsPattern = "[0-9]{4}$";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var correctDateTime = Regex.Replace(reader.GetInt64().ToString(), LastFourDigitsPattern, "0");
            return DateTimeOffset.FromUnixTimeSeconds(long.Parse(correctDateTime)).LocalDateTime;
        }


        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var unixTimestamp = ((DateTimeOffset) value).ToUnixTimeSeconds();
            var correctedUnixTimestamp = Regex.Replace(unixTimestamp.ToString(), LastDigitPattern, "1000");
            writer.WriteNumberValue(long.Parse(correctedUnixTimestamp));
        }
    }
}