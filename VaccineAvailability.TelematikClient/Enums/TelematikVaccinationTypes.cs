using System.Runtime.Serialization;

namespace VaccineAvailability.TelematikClient.Enums
{
    public enum TelematikVaccinationTypes
    {
        Undefined,
     
        [EnumMember(Value = "L920")] BioNTech,

        [EnumMember(Value = "L921")] Moderna,

        [EnumMember(Value = "L922")] AstraZeneca
    }
}