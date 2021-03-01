using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VaccineAvailability.TelematikClient.Models
{
    public class AppointmentLookupModel
    {
        [JsonPropertyName("gesuchteLeistungsmerkmale")]
        public List<string> VaccineTypes { get; set; }

        [JsonPropertyName("terminpaare")] public List<List<AppointmentModel>> Appointments { get; set; }
    }
}