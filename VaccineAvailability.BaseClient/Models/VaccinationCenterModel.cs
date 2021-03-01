using VaccineAvailability.BaseClient.Enums;

namespace VaccineAvailability.BaseClient.Models
{
    public class VaccinationCenterModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public States State { get; set; }
    }
}