using System.Text.Json.Serialization;
using VaccineAvailability.TelematikClient.Enums;

namespace VaccineAvailability.TelematikClient.Models
{
    public class VaccineTypeModel
    {
        [JsonPropertyName("qualification")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TelematikVaccinationTypes Type { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("interval")] public int VaccinationInterval { get; set; }
    }
}