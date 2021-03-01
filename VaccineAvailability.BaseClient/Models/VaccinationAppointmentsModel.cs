using System;

namespace VaccineAvailability.BaseClient.Models
{
    public class VaccinationAppointmentsModel
    {
        public DateTime FirstAppointment { get; set; }

        public DateTime? SecondAppointment { get; set; }
    }
}