using System.Threading.Tasks;
using Refit;
using VaccineAvailability.TelematikClient.Enums;
using VaccineAvailability.TelematikClient.Models;
using VaccineAvailability.TelematikClient.Models.Vaccine;

namespace VaccineAvailability.TelematikClient.Interfaces
{
    public interface ITelematikRestClient
    {
        [Get("/rest/version")]
        Task<string> GetApiVersion();

        [Get("/rest/suche/termincheck?plz={postalCode}&leistungsmerkmale={vaccineType}")]
        Task<VaccineAvailableModel> IsVaccineAvailable(TelematikVaccinationTypes vaccineType, string postalCode);

        [Get("/rest/suche/terminpaare?plz={postalCode}")]
        Task<AppointmentLookupModel> GetAvailableAppointments([Authorize("Basic")] string authorizationId,
            string postalCode);
    }
}