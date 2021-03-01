using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using VaccineAvailability.TelematikClient.Models;

namespace VaccineAvailability.TelematikClient.Interfaces
{
    public interface ITelematikStaticAssetsClient
    {
        [Get("/assets/static/impfzentren.json")]
        Task<Dictionary<string, List<TelematikVaccinationCenterModel>>> GetVaccinationCenters();

        [Get("/assets/static/its/vaccination-list.json")]
        Task<IList<VaccineTypeModel>> GetAvailableVaccineTypes();
    }
}