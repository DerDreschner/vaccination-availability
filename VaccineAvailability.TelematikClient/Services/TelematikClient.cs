using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using VaccineAvailability.BaseClient;
using VaccineAvailability.BaseClient.Interfaces;
using VaccineAvailability.BaseClient.Models;
using VaccineAvailability.TelematikClient.Enums;
using VaccineAvailability.TelematikClient.Interfaces;
using VaccineAvailability.TelematikClient.Models;

namespace VaccineAvailability.TelematikClient.Services
{
    public class TelematikClient : IBaseClient
    {
        private readonly ITelematikStaticAssetsClient _staticAssetsClient;
        private readonly IAuthenticationService _authenticationService;


        public TelematikClient(ITelematikStaticAssetsClient staticAssetsClient, IAuthenticationService authenticationService)
        {
            _staticAssetsClient = staticAssetsClient;
            _authenticationService = authenticationService;
        }


        public async Task<IList<VaccinationCenterModel>> GetVaccinationCenters()
        {
            var vaccinationCenters = await _staticAssetsClient.GetVaccinationCenters();

            var listOfVaccinationCenters = new List<VaccinationCenterModel>();

            foreach (var stateVaccinationCenters in vaccinationCenters)
                stateVaccinationCenters.Value.ForEach(x => listOfVaccinationCenters.Add(x.ToBaseModel()));

            return listOfVaccinationCenters;
        }

        public async Task<bool> AreAppointmentsAvailableFor(string postalCode, VaccineTypes vaccine)
        {
            var vaccinationCenters = await GetVaccinationCentersAsFlatList();

            var vaccinationCenter = vaccinationCenters.First(x => x.PostalCode.Equals(postalCode));

            var restService = RestService.For<ITelematikRestClient>(vaccinationCenter.RegistrationUrl);

            var restResult = await restService.IsVaccineAvailable((TelematikVaccinationTypes) vaccine, postalCode);

            return restResult.VaccineAvailable;
        }

        public async Task<IList<VaccinationAppointmentsModel>> GetAppointmentsFor(string postalCode, string authenticationCode)
        {
            var listOfVaccinationCenters = await GetVaccinationCentersAsFlatList();

            var desiredVaccinationCenter = listOfVaccinationCenters.First(x => x.PostalCode.Equals(postalCode));

            var telematikRestService = RestService.For<ITelematikRestClient>(desiredVaccinationCenter.RegistrationUrl);

            var availableAppointments = await telematikRestService.GetAvailableAppointments(_authenticationService.GenerateAuthToken(authenticationCode), postalCode);

            var appointmentList = new List<VaccinationAppointmentsModel>();

            availableAppointments.Appointments.ForEach(x => appointmentList.Add(new VaccinationAppointmentsModel{
                FirstAppointment = x[0].AppointmentDateTime,
                SecondAppointment = x[1].AppointmentDateTime
            }));

            return appointmentList;
        }

        private async Task<List<TelematikVaccinationCenterModel>> GetVaccinationCentersAsFlatList()
        {
            var vaccinationCenters = await _staticAssetsClient.GetVaccinationCenters();

            var listOfVaccinationCenters = new List<TelematikVaccinationCenterModel>();

            foreach (var stateVaccinationCenters in vaccinationCenters)
                stateVaccinationCenters.Value.ForEach(x => listOfVaccinationCenters.Add(x));

            return listOfVaccinationCenters;
        }
    }
}