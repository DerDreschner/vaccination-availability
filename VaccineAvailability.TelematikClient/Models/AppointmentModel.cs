using System;
using System.Text.Json.Serialization;
using VaccineAvailability.TelematikClient.Converters;

namespace VaccineAvailability.TelematikClient.Models
{
    public class AppointmentModel
    {
        [JsonPropertyName("begin")]
        [JsonConverter(typeof(TelematikDateTimeConverter))]
        public DateTime AppointmentDateTime { get; set; }
    }
}