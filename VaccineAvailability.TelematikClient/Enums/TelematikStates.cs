using System.Runtime.Serialization;

namespace VaccineAvailability.TelematikClient.Enums
{
    public enum TelematikStates
    {
        [EnumMember(Value = "Baden-Württemberg")]
        BW,

        [EnumMember(Value = "Brandenburg")] BB,

        [EnumMember(Value = "Hamburg")] HH,

        [EnumMember(Value = "Hessen")] HE,

        [EnumMember(Value = "Nordrhein-Westfalen")]
        NW,

        [EnumMember(Value = "Sachsen-Anhalt")] ST
    }
}