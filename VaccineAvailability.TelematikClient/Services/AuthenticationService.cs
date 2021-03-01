using System;
using System.Text;
using VaccineAvailability.TelematikClient.Interfaces;

namespace VaccineAvailability.TelematikClient.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public string GenerateAuthToken(string exchangeCode)
        {
            var token = ":" + exchangeCode;

            var tokenAsBytes = Encoding.UTF8.GetBytes(token);
            
            return Convert.ToBase64String(tokenAsBytes);
        }
    }
}