using Microsoft.Extensions.DependencyInjection;
using Refit;
using VaccineAvailability.BaseClient.Interfaces;
using VaccineAvailability.TelematikClient.Interfaces;
using VaccineAvailability.TelematikClient.Services;

namespace VaccineAvailability.TelematikClient.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_ =>
                RestService.For<ITelematikStaticAssetsClient>("https://www.impfterminservice.de"));
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IBaseClient, Services.TelematikClient>();
        }
    }
}