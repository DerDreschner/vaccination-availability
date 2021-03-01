using System.Text.Json.Serialization;

namespace VaccineAvailability.TelematikClient.Models.Vaccine
{
    public class VaccineAvailableModel
    {
        [JsonPropertyName("termineVorhanden")] public bool VaccineAvailable { get; set; }
    }
}