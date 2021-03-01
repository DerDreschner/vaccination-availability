using System.Collections.Generic;
using System.Threading.Tasks;
using VaccineAvailability.BaseClient.Models;

namespace VaccineAvailability.BaseClient.Interfaces
{
    public interface IBaseClient
    {
        Task<IList<VaccinationCenterModel>> GetVaccinationCenters();

        Task<bool> AreAppointmentsAvailableFor(string postalCode, VaccineTypes vaccine);

        Task<IList<VaccinationAppointmentsModel>> GetAppointmentsFor(string postalCode, string authenticationCode = "");
    }
}