namespace VaccineAvailability.TelematikClient.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateAuthToken(string exchangeCode);
    }
}