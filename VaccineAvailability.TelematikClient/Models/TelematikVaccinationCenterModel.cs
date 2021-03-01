using System.Text.Json.Serialization;
using VaccineAvailability.BaseClient.Enums;
using VaccineAvailability.BaseClient.Models;
using VaccineAvailability.TelematikClient.Enums;

namespace VaccineAvailability.TelematikClient.Models
{
    public class TelematikVaccinationCenterModel
    {
        [JsonPropertyName("Zentrumsname")] public string Name { get; set; }

        [JsonPropertyName("PLZ")] public string PostalCode { get; set; }

        [JsonPropertyName("Ort")] public string City { get; set; }

        [JsonPropertyName("Bundesland")]
        [JsonConverter(typeof(JsonStringEnumMemberConverter))]
        public TelematikStates TelematikState { get; set; }

        [JsonPropertyName("URL")] public string RegistrationUrl { get; set; }

        [JsonPropertyName("Adresse")] public string Address { get; set; }

        public VaccinationCenterModel ToBaseModel()
        {
            return new()
            {
                Name = Name,
                Address = Address,
                City = City,
                PostalCode = PostalCode,
                State = (States) TelematikState
            };
        }
    }
}